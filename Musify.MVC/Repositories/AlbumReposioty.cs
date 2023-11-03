using Microsoft.EntityFrameworkCore;
using Musify.MVC.Data;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public class AlbumReposioty : Genaricepository<Album>, IAlbumRepository
    {
        private readonly MusifyDbContext _dbContext;

        public AlbumReposioty(MusifyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Album> GetAlbumWithSongs(Guid id)
        {
            var album = await _dbContext.Albums.Include(x => x.Songs).FirstOrDefaultAsync(x => x.Id == id);
            return album;

        }
    }
}
