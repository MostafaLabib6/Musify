using Musify.MVC.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Musify.MVC.Models.Entities;

public class Song : BaseEntity
{
    [Required(ErrorMessage = "Song Image is Required")]
    public string Image { get; set; }

    [Required(ErrorMessage = "Song is Required")]
    public string Audio { get; set; }
    public string Video { get; set; }
    public DateTime ReleaseAt { get; set; } = DateTime.Now;
    public int Likes { get; set; }
    public Tag Tag { get; set; }
    public Type Type { get; set; }
    public ICollection<Artist> Artists { get; set; } = new List<Artist>();
    public ICollection<Playlist> Playlists { get; set; }

    //public string Lyrics { get; set; }


}
