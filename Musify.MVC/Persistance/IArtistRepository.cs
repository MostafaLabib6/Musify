using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public interface IArtistRepository : IGenaricRepository<Artist>
    {
        public Task<Artist> GetArtistWithSongs(Guid id);
        public Task<Artist> GetArtistWithAlbum(Guid id);
    }
}
