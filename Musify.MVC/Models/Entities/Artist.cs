namespace Musify.MVC.Models.Entities;

public class Artist : User
{
    public ICollection<Song> Songs { get; set; } = new List<Song>();
    public ICollection<Album> Albums { get; set; } = new List<Album>();
}