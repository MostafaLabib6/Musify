using Microsoft.AspNetCore.Identity;

namespace Musify.MVC.Models.Entities;

public class User : IdentityUser
{
    //TODO:Add user's avatar 
    public ICollection<User> Followers { get; set; } = new List<User>();
    public int FollowersCount { get; set; }
    public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

}