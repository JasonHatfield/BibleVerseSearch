using BibleVerseSearch.BusinessLogic;
using BibleVerseSearch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibleVerseSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VerseBLL _verseBLL;

        // Dependency injection of logger and VerseBLL
        public HomeController(ILogger<HomeController> logger, VerseBLL verseBLL)
        {
            _logger = logger;
            _verseBLL = verseBLL;
        }

        // Action method for the home page
        public IActionResult Index()
        {
            return View();
        }

        // Action method for the checklist page
        public IActionResult Checklist()
        {
            return View();
        }

        // Action method for the search page
        public IActionResult Search()
        {
            return View();
        }

        // Action method for searching verses
        [HttpGet]
        public IActionResult SearchVerses(string searchTerm, string testament)
        {
            // Convert testament string to enum
            Testament testamentEnum;
            switch (testament)
            {
                case "Old":
                    testamentEnum = Testament.Old;
                    break;
                case "New":
                    testamentEnum = Testament.New;
                    break;
                default:
                    testamentEnum = Testament.Both;
                    break;
            }

            // Get verses from VerseBLL
            var verses = _verseBLL.GetVerses(searchTerm, testamentEnum);
            return Json(verses);
        }

        // Action method for the privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method for the error page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
