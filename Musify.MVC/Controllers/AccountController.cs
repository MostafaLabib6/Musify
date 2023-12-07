
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Musify.MVC.Infrastructure.IdentityService;
using Musify.MVC.Models.DTOs;

namespace Musify.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly Serilog.ILogger _logger;
        public AccountController(IAuthenticationService authenticationService, Serilog.ILogger logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
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

            return View("RegisterComplete", result);

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
