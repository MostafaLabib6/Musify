using Microsoft.EntityFrameworkCore;
using Musify.MVC.Data;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public class PlaylistRepository : Genaricepository<Playlist>, IPlaylistRepository
    {
        private readonly MusifyDbContext _dbContext;

        public PlaylistRepository(MusifyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Playlist> GetPlaylistWithSongs(Guid id)
        {
            var playlist = await _dbContext.Playlists.Include(x => x.Songs).FirstOrDefaultAsync(x => x.Id == id);
            return playlist;
        }
    }
}
