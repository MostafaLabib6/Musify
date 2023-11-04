using Musify.MVC.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musify.MVC.Models.Entities;

public class Playlist : BaseEntity
{
    public Author Author { get; set; } //author == user
    public bool IsPublic { get; set; }
    public bool Shuffle { get; set; }
    public Guid SongId { get; set; }
    [ForeignKey(nameof(SongId))]
    public ICollection<Song> Songs { get; set; }

}
