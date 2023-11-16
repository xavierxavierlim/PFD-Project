using Microsoft.AspNetCore.Mvc;
using PFD_Project.Models;
using System.Diagnostics;
using PFD_Project.DAL;
using System.Net.NetworkInformation;
using Rsk.AspNetCore.Fido;
using Rsk.AspNetCore.Fido.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Web.Helpers;


namespace PFD_Project.Controllers
{
    public class HomeController : Controller
    {

        private UsersDAL usersContext = new UsersDAL();
        private TransactionsDAL transactionContext = new TransactionsDAL();
        private RiskDAL riskContext = new RiskDAL();
        private FeedbackDAL feedbackContext = new FeedbackDAL();

        private readonly ILogger<HomeController> _logger;
        private readonly IFidoAuthentication fido;

        public HomeController(ILogger<HomeController> logger, IFidoAuthentication fido)
        {
            _logger = logger;
            this.fido = fido ?? throw new ArgumentNullException(nameof(fido));
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BalanceEnquiry()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Pin(LoginModel? user)
        {
            return View(user);
        }

        public ActionResult AccountNumber()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AccountNumber(IFormCollection formData)
        {
            string accountNo = formData["accountNo"];
            HttpContext.Session.SetString("AccountNo", accountNo);
            LoginModel newUser = new LoginModel();
            if (accountNo != null)
            {
                newUser.UserId = accountNo;
            }
            return RedirectToAction("Pin", newUser);
        }

        [HttpPost]
        public ActionResult Pin(IFormCollection formData)
        {
            string pin = formData["pin1"] + formData["pin2"] + formData["pin3"] + formData["pin4"] + formData["pin5"] + formData["pin6"];
            Console.WriteLine(pin);
            string username = usersContext.GetUserName(pin);
            int userID = usersContext.GetUserID(pin);

            string accountNo = HttpContext.Session.GetString("AccountNo");
            string accountPin = usersContext.GetPin(accountNo);

            if (username != null && pin == accountPin)
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

                CallNotification();
                return RedirectToAction("WithdrawMessage");
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

        public ActionResult FeedbackStars()
        {
            Feedback feedback = new Feedback();
            return View(feedback);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeedbackStars(int star, Feedback newFeedback)
        {
            if (ModelState.IsValid)
            {
                newFeedback.Rating = star;
                newFeedback.UserID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
                newFeedback.FeedbackID = feedbackContext.addFeedbackStars(newFeedback);
                HttpContext.Session.SetInt32("FeedbackID", newFeedback.FeedbackID);
                return RedirectToAction("FeedbackOptions");
            }
            else
            {
                Feedback newFeedbac = new Feedback();
                return View(newFeedback);
            }
        }

        public IActionResult FeedbackOptions()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeedbackOptions(string description, Feedback newFeedback)
        {
            if (ModelState.IsValid)
            {
                feedbackContext.addFeedbackDescription(Convert.ToInt32(HttpContext.Session.GetInt32("FeedbackID")), description);
                return RedirectToAction("Thanks");
            }
            else
            {
                return RedirectToAction("FeedbackOptions");
            }
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

        public IActionResult MoreOption()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Fingerprint Controller
        public IActionResult FingerprintIndex() => View();

        [Authorize]
        public IActionResult Secure() => View("Index");

        public IActionResult StartRegistration() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            var challenge = await fido.InitiateRegistration(model.UserId, model.DeviceName);

            return View(challenge.ToBase64Dto());
        }

        [HttpPost]
        public async Task<IActionResult> CompleteRegistration([FromBody] Base64FidoRegistrationResponse registrationResponse)
        {
            var result = await fido.CompleteRegistration(registrationResponse.ToFidoResponse());

            if (result.IsError) return BadRequest(result.ErrorDescription);
            return Ok();
        }

        public ActionResult StartLogin()
        {
            string accountNo = HttpContext.Session.GetString("AccountNo");
            LoginModel user1 = new LoginModel();
            if (accountNo != null)
            {
                user1.UserId = accountNo;
            }
            return View(user1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var challenge = await fido.InitiateAuthentication(model.UserId);

            return View(challenge.ToBase64Dto());
        }

        [HttpPost]
        public async Task<IActionResult> CompleteLogin([FromBody] Base64FidoAuthenticationResponse authenticationResponse)
        {
            var result = await fido.CompleteAuthentication(authenticationResponse.ToFidoResponse());

            if (result.IsSuccess)
            {
                await HttpContext.SignInAsync("cookie", new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim("sub", result.UserId)
                }, "cookie")));

                string accountNo = HttpContext.Session.GetString("AccountNo");
                string name = usersContext.GetUserNameByAccountNo(accountNo);
                int userID = usersContext.GetUserIDByAccountNo(accountNo);

                HttpContext.Session.SetString("username", name);
                HttpContext.Session.SetInt32("userID", userID);
            }

            if (result.IsError) return BadRequest(result.ErrorDescription);
            return Ok();
        }
        public void CallNotification()
        {
            if (HttpContext.Session.GetInt32("riskFlag") >= 3)
            {
                string accountNo = HttpContext.Session.GetString("AccountNo");
                string name = usersContext.GetUserNameByAccountNo(accountNo) ?? "JIADONG";
                string accountSid = "ACf7fcc346f1d1fc1b8355f14f206328d6";
                string authToken = "bceca3f97f7f9f939efb019b96f7d192";
                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: name.ToUpper() + ": A transaction on " + Convert.ToString(DateTime.Now) + " was flagged as VULNERABLE." +
                    " Contact OCBC customer service or visit a local branch at +65 6363 3333 / OCBC.com to report fraud or theft.",
                    from: new Twilio.Types.PhoneNumber("+12056569336"),
                    to: new Twilio.Types.PhoneNumber("+6597864174")
                );

                Console.WriteLine(message.Sid);
                riskContext.addRisk();
            }
        }
        [HttpPost]
        public void RiskManagement()
        {
            if (HttpContext.Session.GetInt32("riskFlag") != null)
            {
                int count = Convert.ToInt32(HttpContext.Session.GetInt32("riskFlag"));
                count++;
                HttpContext.Session.SetInt32("riskFlag", count);
            }
            else
            {
               HttpContext.Session.SetInt32("riskFlag", 1);
            }
        }
    }
} 