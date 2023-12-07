using System.ComponentModel.DataAnnotations;

namespace Musify.MVC.Models.DTOs;

public class RegistrationModel
{
    [Required]
    public string UserName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required, Compare("Password")]
    public string ConfirmPassword { get; set; }

    public RoleEnum? Role { get; set; }
}
