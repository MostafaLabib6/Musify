
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Musify.MVC.Infrastructure.IdentityService;
using Musify.MVC.Infrastructure.MailService;
using Musify.MVC.Models.DTOs;


namespace Musify.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly Serilog.ILogger _logger;
        private readonly IEmailService _emailService;
        public AccountController(IAuthenticationService authenticationService, Serilog.ILogger logger, IEmailService emailService)
        {
            _authenticationService = authenticationService;
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _authenticationService.Login(model);

            return View("LoginComplete", result);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Register));
            }
            model.Role = RoleEnum.User;
            var result = await _authenticationService.Register(model);

            if (!result.Success)
            {
                return View(model);
            }
            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = result.UserId, token = result.Token }, Request.Scheme);
            var email = new Email()
            {
                Subject = "Confirm your Email (musify)",
                Body = confirmationLink!,
                To = model.Email,
            };
            await _emailService.SendEmail(email);
            return View(model);

        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _authenticationService.FindById(userId!);

            if (user == null)
            {
                // Handle user not 
            }

            var result = await _authenticationService.ConfirmEmail(user, token);

            if (!result.Success)
            {
                await _authenticationService.DeleteUser(userId!);
                return RedirectToAction(nameof(Register));
            }
            return RedirectToAction(nameof(Index), "Home");

        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _authenticationService.ChangePassword(model);

            return View("ChangePasswordComplete", result);

        }
        public async Task<IActionResult> RegisterAdmin(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Register));
            }
            model.Role = RoleEnum.Admin;
            var result = await _authenticationService.Register(model);

            return View(result);

        }
    }
}
