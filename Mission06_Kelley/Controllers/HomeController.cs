using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Mission06_Kelley.Models;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Mission06_Kelley.Controllers
{
    public class HomeController : Controller
    {

        private MovieEntryContext _movieEntryContext;
        public HomeController(MovieEntryContext tempinstance) 
        { 
            _movieEntryContext = tempinstance;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel() 
        { 
            return View();
        }

        [HttpGet]
        public IActionResult MovieEntry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieEntry(Application response) 
        {
            _movieEntryContext.Applications.Add(response); //Add record to database
            _movieEntryContext.SaveChanges();
            return View("Confirmation", response);
        }
    }
}
