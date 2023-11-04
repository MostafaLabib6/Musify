using Musify.MVC.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musify.MVC.Models.Entities;

public class Song : BaseEntity
{
    public string Image { get; set; }
    public string Audio { get; set; }
    public string Video { get; set; }
    //public string Lyrics { get; set; }
    public DateTime ReleaseAt { get; set; } = DateTime.Now;
    public Guid ArtistId { get; set; }
    public int Likes { get; set; }

    [ForeignKey(nameof(ArtistId))]
    public ICollection<Artist> Artists { get; set; }

    public Tag Tag { get; set; }
    public Type Type { get; set; }


}
