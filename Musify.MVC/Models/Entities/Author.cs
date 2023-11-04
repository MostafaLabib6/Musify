using Microsoft.AspNetCore.Identity;
using Musify.MVC.Data;
using Musify.MVC.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musify.MVC.Models.Entities;

public class Author : BaseEntity
{
    public ICollection<Author> Followers { get; set; }
    public int FollowersCount { get; set; }
    public Guid PlayListId { get; set; }
    [ForeignKey(nameof(PlayListId))]
    public ICollection<Playlist> Playlists { get; set; }

    //Authorid | Authorid
    //    1       3
    //    1       4
}