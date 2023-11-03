using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public interface IAlbumRepository:IGenaricRepository<Album>
    {
        public Task<Album> GetAlbumWithSongs(Guid id);

    }
}
