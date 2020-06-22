using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicAppMVC.Models;

namespace MusicAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMusicFileRepository _musicFileRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMusicFileRepository musicFileRepository, ILogger<HomeController> logger)
        {
            _musicFileRepository = musicFileRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
