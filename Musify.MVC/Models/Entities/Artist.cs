using System.ComponentModel.DataAnnotations.Schema;

namespace Musify.MVC.Models.Entities;

public class Artist : Author
{
    public Guid SongId { get; set; }

    [ForeignKey(nameof(SongId))]
    public ICollection<Song> Songs { get; set; }
    public Album Album { get; set; }
}