using Microsoft.AspNetCore.Mvc;
using PFD_Project.Models;
using System.Diagnostics;
using PFD_Project.DAL;
using PFD_Project.Models;

namespace PFD_Project.Controllers
{
    public class HomeController : Controller
    {
        private UsersDAL usersContext = new UsersDAL();
		private TransactionsDAL transactionContext = new TransactionsDAL();

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
        public ActionResult Pin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pin(IFormCollection formData)
        {
            string pin = formData["pin"].ToString();
            string username = usersContext.GetUserName(pin);
            int userID = usersContext.GetUserID(pin);
            if (username != null)
            {
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetInt32("userID", userID);
                return RedirectToAction("Home");
            }
            else
            {
                TempData["Message"] = "Invalid pin";
                return RedirectToAction("Pin");          
            }
        }

        public ActionResult Home()
        {
            string name = HttpContext.Session.GetString("username");
            ViewData["Name"] = name;
            Transactions newTrans = new Transactions();
            return View(newTrans);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Home(decimal amount, Transactions newTrans)
        {
            if (ModelState.IsValid)
            {
                newTrans.UserID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
                newTrans.TransactionDate = DateTime.Now;
                newTrans.Amount = amount;
                newTrans.TransactionType = "Withdraw";
                newTrans.TransactionID = transactionContext.addTransaction(newTrans);
                return RedirectToAction();
            }
            else
            {
                Transactions newTran = new Transactions();

				return View(newTran);
            }

        }
        public IActionResult Privacy()
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

        public IActionResult TransferConfirmation()
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