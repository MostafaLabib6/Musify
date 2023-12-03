using Musify.MVC.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musify.MVC.Models.Entities;

public class Album : BaseEntity
{
    public ICollection<Song> Songs { get; set; } = new List<Song>();
}