using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppMVC.Models
{
    public interface IMusicFileRepository
    {
        MusicFile GetMusicFile(int id);
        IEnumerable<MusicFile> GetAllMusicFiles();
        MusicFile Add(MusicFile musicFile);
        MusicFile Update(MusicFile musicFileChanges);
        MusicFile Delete(int id);
    }
}
