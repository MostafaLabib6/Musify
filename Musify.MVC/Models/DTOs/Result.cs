namespace Musify.MVC.Models.DTOs;

public class Result
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public string Token { get; set; } = string.Empty;
    public Guid UserId { get; set; } 
}



/*
 creation of email 
   if  email is exist;
    return result{
        status = -1;
        message = "email already taken";
    }
 
 
 */
