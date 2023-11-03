using Musify.MVC.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musify.MVC.Models.Entities;

public class Album : BaseEntity
{
    [ForeignKey(nameof(SongId))]
    public ICollection<Song> Songs { get; set; }
    public Guid SongId { get; set; }
}