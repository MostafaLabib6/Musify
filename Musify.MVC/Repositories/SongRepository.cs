using Microsoft.EntityFrameworkCore;
using Musify.MVC.Data;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public class SongRepository : Genaricepository<Song>, ISongRepository
    {
        private readonly MusifyDbContext _dbContext;

        public SongRepository(MusifyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Song>> GetLatestReleased6Songs()
        {
            return await _dbContext.Songs.OrderByDescending(s => s.ReleaseAt).Take(6).Include(x => x.Artists).ToListAsync();
        }

        public Task<Song> GetSongWithArtist(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
