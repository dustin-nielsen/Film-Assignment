using Film_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Film_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private MovieSubmissionContext daContext { get; set; }

        public HomeController(MovieSubmissionContext x)
        {
            daContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSubmission()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieSubmission (MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(mr);
                daContext.SaveChanges();

                return View("Confirmation", mr);
            }
            else //If Invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View();
            }

        }

        public IActionResult MovieList ()
        {
            var applications = daContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var application = daContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View("MovieSubmission", application);
        }

        [HttpPost]
        public IActionResult Edit(MovieResponse blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int applicationid)
        { 
            var application = daContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete (MovieResponse mr)
        {
            daContext.Responses.Remove(mr);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
