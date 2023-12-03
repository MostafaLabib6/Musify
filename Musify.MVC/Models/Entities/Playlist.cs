using Musify.MVC.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musify.MVC.Models.Entities;

public class Playlist : BaseEntity
{
    
    public User Author { get; set; } = new();
    public bool IsPublic { get; set; }
    public bool Shuffle { get; set; }
    public ICollection<Song> Songs { get; set; } = new List<Song>();

}
