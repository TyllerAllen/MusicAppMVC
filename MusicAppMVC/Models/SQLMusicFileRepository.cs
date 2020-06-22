using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppMVC.Models
{
    public class SQLMusicFileRepository : IMusicFileRepository
    {
        private readonly AppDbContext _context;
        public SQLMusicFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public MusicFile Add(MusicFile musicFile)
        {
            _context.MusicFiles.Add(musicFile);
            _context.SaveChanges();
            return musicFile;
        }

        public MusicFile Delete(int id)
        {
            MusicFile musicFile = _context.MusicFiles.Find(id);
            if(musicFile != null)
            {
                _context.MusicFiles.Remove(musicFile);
                _context.SaveChangesAsync();
            }
            return musicFile;
        }

        public IEnumerable<MusicFile> GetAllMusicFiles()
        {
            return _context.MusicFiles;
        }

        public MusicFile GetMusicFile(int id)
        {
            return _context.MusicFiles.Find(id);
        }

        public MusicFile Update(MusicFile musicFileChanges)
        {
            var musicFile = _context.MusicFiles.Attach(musicFileChanges);
            musicFile.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return musicFileChanges;
        }
    }
}
