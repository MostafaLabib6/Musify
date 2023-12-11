using Microsoft.AspNetCore.Identity;
using Musify.MVC.Models.DTOs;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Infrastructure.IdentityService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly Serilog.ILogger _logger;

        public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, Serilog.ILogger logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<Result> ChangePassword(ChangePassword changePassword)
        {
            var result = new Result();
            //Check if email exist or not 
            var user = await _userManager.FindByEmailAsync(changePassword.Email);
            if (user == null)
            {
                result.Success = false;
                result.Message = "Email is not Found";
                return result;
            }
            var identityResult = await _userManager.ChangePasswordAsync(user, changePassword.Password, changePassword.NewPassword);
            if (!identityResult.Succeeded)
            {
                result.Success = false;
                result.Message = "Invalid Email or Password";
                return result;
            }
            result.Success = true;
            result.Message = "Password Changed Successfully.";
            return result;
        }

        public async Task<Result> ConfirmEmail(User user, string token)
        {
            var result = new Result();
            var identity = await _userManager.ConfirmEmailAsync(user, token);
            result.Success = identity.Succeeded;
            result.Message = (identity.Succeeded) ? "" : "Not confirmed..";
            return result;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await FindById(userId);
            var identityResult = await _userManager.DeleteAsync(user);
            return identityResult.Succeeded;
        }

        public async Task<User> FindById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public Task<Result> ForgetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateToken(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<Result> Login(LoginModel loginModel)
        {
            var result = new Result();
            //Check if email exist or not 
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
            {
                result.Success = false;
                result.Message = "Email is not Found";
                return result;
            }

            var signinResult = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, true);
            if (!signinResult.Succeeded)
            {
                result.Success = false;
                result.Message = "Invalid Password or Email";
                return result;
            }

            result.Success = true;
            result.Message = "Login successfuly";
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public Task<Result> Profile(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> Register(RegistrationModel registrationModel)
        {
            var result = new Result();

            //Check if email exist or not 
            var userEmail = await _userManager.FindByEmailAsync(registrationModel.Email);
            if (userEmail != null)
            {
                result.Success = false;
                result.Message = "Email is already Taken..";
                return result;
            }

            //Account Creation
            var user = new User()
            {
                UserName = registrationModel.UserName,
                Email = registrationModel.Email,
                SecurityStamp = new Guid().ToString(),

            };
            // Create role if the passed role is not exist.
            //if (!await _roleManager.RoleExistsAsync(registrationModel.Role.ToString()))
            await _roleManager.CreateAsync(new IdentityRole(registrationModel.Role.ToString()));
            //else
            //    await _userManager.AddToRoleAsync(user, registrationModel.Role.ToString());

            var isCreated = await _userManager.CreateAsync(user, registrationModel.Password);
            var token = await GenerateToken(user);

            if (!isCreated.Succeeded)
            {
                result.Success = false;
                result.Message = "Registaration Failed..";
                return result;
            }
            result.Success = true;
            result.Message = "Registar Successfully..";
            result.Token = token;
            result.UserId = new Guid(user.Id);
            return result;
        }
    }
}
