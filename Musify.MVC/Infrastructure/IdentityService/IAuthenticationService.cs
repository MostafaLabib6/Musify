using Musify.MVC.Models.DTOs;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Infrastructure.IdentityService
{
    public interface IAuthenticationService
    {
        public Task<Result> Login(LoginModel loginModel);
        public Task Logout();
        public Task<Result> Register(RegistrationModel registrationModel);
        public Task<Result> ChangePassword(ChangePassword changePassword);
        public Task<Result> ForgetPassword(string email);
        public Task<Result> Profile(string userId);
        public Task<string> GenerateToken(User user);
        public Task<User> FindById(string userId);
        Task<Result> ConfirmEmail(User user, string token);
        public Task<bool> DeleteUser(string userId);
    }
}
//TODO:external login with facebook and google