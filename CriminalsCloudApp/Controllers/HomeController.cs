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
           

        }

        public IActionResult Index()

        {
            criminalDao criminalDao = new criminalDao();
            List<Criminal> criminals = criminalDao.GetAllCriminals();
        
            //new Criminal(1, "John Doe", "Male", "Black", "Blue", "6'0\"", "Athletic", "Fingerprint #1", "No"),
            //new Criminal(2, "Jane Smith", "Female", "Brown", "Green", "5'8\"", "Slim", "Fingerprint #2", "Yes"),
            //new Criminal(3, "Mike Johnson", "Male", "Blonde", "Brown", "5'10\"", "Average", "Fingerprint #3", "No"),
            //new Criminal(4, "Emily Davis", "Female", "Red", "Hazel", "5'6\"", "Slim", "Fingerprint #4", "No"),
            //new Criminal(5, "David Wilson", "Male", "Brown", "Blue", "5'11\"", "Stocky", "Fingerprint #5", "No"),
            //new Criminal(6, "Sarah Parker", "Female", "Black", "Brown", "5'7\"", "Slim", "Fingerprint #6", "Yes"),
            //new Criminal(7, "Chris Thompson", "Male", "Brown", "Green", "6'2\"", "Athletic", "Fingerprint #7", "No"),
            //new Criminal(8, "Lisa Adams", "Female", "Blonde", "Blue", "5'5\"", "Slim", "Fingerprint #8", "No"),
            //new Criminal(9, "Matt Harris", "Male", "Brown", "Brown", "5'9\"", "Average", "Fingerprint #9", "No"),
            //new Criminal(10, "Amy White", "Female", "Brown", "Hazel", "5'6\"", "Slim", "Fingerprint #10", "Yes")
        
            
            return View(criminals);
        }

        public IActionResult SubmitFilter(string name, string sex, string hair, string eyes, string height, string build, string fingerPrint, string glasses)
        {
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
