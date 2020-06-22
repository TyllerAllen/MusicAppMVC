using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAppMVC.Models;
using MusicAppMVC.ViewModels;
using TagLib;

namespace MusicAppMVC.Controllers
{
    public class MusicFilesController : Controller
    {
        private readonly IMusicFileRepository _musicFileRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MusicFilesController(IMusicFileRepository musicFileRepository, IWebHostEnvironment webHostEnvironment)
        {
            _musicFileRepository = musicFileRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MusicFileCreateViewModel model)
        {
            if (ModelState.IsValid && model.Files != null)
            {
                foreach(var file in model.Files)
                {
                    // The files must be uploaded to their respective folder in wwwroot
                    string songsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "songs");
                    string albumArtFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                    // A new GUID value ensures a unique file name
                    string songFileName = Guid.NewGuid().ToString() + ".mp3";
                    string songFilePath = Path.Combine(songsFolder, songFileName);

                    // Copy the file to the wwwroot/songs folder
                    // Using block automatically disposes the file stream at the end
                    using (FileStream fileStream = new FileStream(songFilePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Open the file using TagLib-Sharp
                    var tagLibFile = TagLib.File.Create(songFilePath);

                    string albumArtFileName = null;

                    if (tagLibFile.Tag.Pictures.Length >= 1)
                    {
                        string imageType = tagLibFile.Tag.Pictures[0].MimeType.Split("/").Last();

                        // A new GUID value ensures a unique file name
                        albumArtFileName = Guid.NewGuid().ToString() + "." + imageType;
                        string albumArtFilePath = Path.Combine(albumArtFolder, albumArtFileName);

                        // Copy the album art to the wwwroot/images folder
                        using (FileStream fileStream = new FileStream(albumArtFilePath, FileMode.Create))
                        {
                            fileStream.Write(tagLibFile.Tag.Pictures[0].Data.Data);
                        }
                    }

                    Genre genre = Genre.NONE;

                    try
                    {
                        genre = (Genre)Enum.Parse(typeof(Genre), tagLibFile.Tag.FirstGenre, true);
                    }
                    catch (Exception)
                    {
                        // Genre will default to NONE if no match is found
                    }

                    MusicFile musicFile = new MusicFile
                    {
                        FilePath = songFileName,
                        IsChecked = false,
                        AlbumArtPath = albumArtFileName,
                        FileName = file.FileName,
                        Title = tagLibFile.Tag.Title,
                        Artist = tagLibFile.Tag.FirstPerformer,
                        Genre = genre
                    };

                    _musicFileRepository.Add(musicFile);
                }
            }
            return View();
        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _musicFileRepository.GetAllMusicFiles().ToList() });
        }
        #endregion
    }
}