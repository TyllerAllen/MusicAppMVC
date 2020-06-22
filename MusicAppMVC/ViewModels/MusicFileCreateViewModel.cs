using Microsoft.AspNetCore.Http;
using MusicAppMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppMVC.ViewModels
{
    public class MusicFileCreateViewModel
    {
        public List<IFormFile> Files { get; set; }
        public IEnumerable<MusicFile> MusicFiles { get; set; }
    }
}
