using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Mission06_Kelley.Models;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;

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
            ViewBag.CategoryList = _movieEntryContext.Categories
                 .ToList();
            return View("MovieEntry");
        }
        [HttpPost]
        public IActionResult MovieEntry(Application response) 
        {
            _movieEntryContext.Movies.Add(response); //Add record to database
            _movieEntryContext.SaveChanges();
            return View("Confirmation", response);
        }

        public IActionResult Movies()
        {
            var applications = _movieEntryContext.Movies.Include("Category")
                .OrderBy(x => x.Title).ToList();
            
                return View(applications);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _movieEntryContext.Movies
                .Single(x => x.MovieId == id);

            ViewBag.CategoryList = _movieEntryContext.Categories
            .ToList();

            return View("MovieEntry", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _movieEntryContext.Update(updatedInfo);
            _movieEntryContext.SaveChanges();

            return RedirectToAction("Movies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _movieEntryContext.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Application application)
        {
            _movieEntryContext.Movies.Remove(application);
            _movieEntryContext.SaveChanges();

            return RedirectToAction("Movies");
        }
    }
}
