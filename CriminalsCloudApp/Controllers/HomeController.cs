using CriminalsCloudApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using CriminalsCloudApp.Interfaces;

namespace CriminalsCloudApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "Nlog injected into Home Controller");

        }

        public IActionResult Index()

        {
            _logger.LogInformation("This is the index of our homepage");
            criminalDao criminalDao = new criminalDao();
            List<Criminal> criminals = criminalDao.GetAllCriminals();
       
            
            return View(criminals);
        }

        public IActionResult SubmitFilter(string name, string sex, string hair, string eyes, string height, string build, string fingerPrint, string glasses)
        {
            _logger.LogInformation("Searching criminals with specific attibutes");
            criminalDao criminalDao = new criminalDao();
            // Call the SelectByAttributes method with the selected values
            List<Criminal> filteredCriminals = criminalDao.SelectByAttributes(name, sex, hair, eyes, height, build, fingerPrint, glasses);

            // Pass the filteredCriminals to the view or perform any desired processing
            return View("Index", filteredCriminals);
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
