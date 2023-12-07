using Musify.MVC.Models.DTOs;

namespace Musify.MVC.Infrastructure.IdentityService
{
    public interface IAuthenticationService
    {
        public Task<Result> Login(LoginModel loginModel);
        public Task Logout();
        public Task<Result> Register(RegistrationModel registrationModel);
        public Task<Result> ChangePassword(ChangePassword changePassword);
    }
}
