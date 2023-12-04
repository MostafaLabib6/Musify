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
            return await _dbContext.Songs.OrderByDescending(s => s.ReleaseAt).Include(x => x.Artists).Take(6).ToListAsync();
        }

        public async Task<Song> GetSongWithArtist(Guid id)
        {
            return await _dbContext.Songs.
                Include(x => x.Artists).
                FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ArgumentNullException("Song not Found");
        }

    }
}
