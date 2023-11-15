using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PFD_Project.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rsk.AspNetCore.Fido;
using Rsk.AspNetCore.Fido.Dtos;

namespace PFD_Project.Controllers
{
    public class FingerprintController : Controller
    {
        private readonly IFidoAuthentication fido;

        public FingerprintController(IFidoAuthentication fido)
        {
            this.fido = fido ?? throw new ArgumentNullException(nameof(fido));
        }

        public IActionResult Index() => View();

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
            }

            if (result.IsError) return BadRequest(result.ErrorDescription);
            return Ok();
        }
    }
}
