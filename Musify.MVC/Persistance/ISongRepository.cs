using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public interface ISongRepository : IGenaricRepository<Song>
    {
        public Task<Song> GetSongWithArtist(Guid id);
        public Task<List<Song>> GetLatestReleased6Songs();

    }
}
