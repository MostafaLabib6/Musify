using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public interface IPlaylistRepository : IGenaricRepository<Playlist>
    {
        public Task<Playlist> GetPlaylistWithSongs(Guid id);

    }
}
