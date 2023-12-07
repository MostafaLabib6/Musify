using System.ComponentModel.DataAnnotations;

namespace Musify.MVC.Models.DTOs;

public class ChangePassword
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string NewPassword { get; set; }

}
