using System.Diagnostics;
using ArtPromptChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtPromptChallenge.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }
        [HttpGet("/privacy")]
        public IActionResult Privacy() {
            return View();
        }

        [HttpGet("/examplesc")]
        public IActionResult ExampleSc() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}