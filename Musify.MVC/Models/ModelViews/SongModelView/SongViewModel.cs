using System.Security.Principal;

namespace Musify.MVC.Models.ModelViews.SongModelView
{
    public class SongViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Audio { get; set; }
        public Guid ArtistId { get; set; }
        public string ArtistName { get; set; }
    }
}
