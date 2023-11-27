using Filebrowser.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Filebrowser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            var imageFiles = Directory.GetFiles(imagePath, "*.jpg").Select(Path.GetFileName);

            ViewBag.ImageFiles = imageFiles;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}