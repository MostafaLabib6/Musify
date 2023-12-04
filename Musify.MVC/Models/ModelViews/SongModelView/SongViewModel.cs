using Microsoft.AspNetCore.Mvc.Authorization;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Models.ModelViews.SongModelView;

public class SongViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Audio { get; set; }
    public List<Artist> Artists { get; set; }
}