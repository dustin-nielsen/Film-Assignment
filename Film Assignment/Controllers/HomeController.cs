using Film_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieSubmissionContext blahContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieSubmissionContext x)
        {
            _logger = logger;
            blahContext = x;
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
            return View();
        }

        [HttpPost]
        public IActionResult MovieSubmission (MovieResponse mr)
        {
            if (ModelState.IsValid == true)
            {
                blahContext.Add(mr);
                blahContext.SaveChanges();
            }
                

            return View("Confirmation", mr);
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
