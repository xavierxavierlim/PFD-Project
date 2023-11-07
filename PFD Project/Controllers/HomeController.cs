using Microsoft.AspNetCore.Mvc;
using PFD_Project.Models;
using System.Diagnostics;


namespace PFD_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Pin()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Receipt()
        {
            return View();
        }

        public IActionResult WithdrawMessage()
        {
            return View();
        }

        public IActionResult FeedbackStars()
        {
            return View();
        }

        public IActionResult FeedbackOptions()
        {
            return View();
        }

        public IActionResult Thanks()
        {
            return View();
        }

        public IActionResult WithdrawAmount()
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