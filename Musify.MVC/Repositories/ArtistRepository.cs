using Microsoft.EntityFrameworkCore;
using Musify.MVC.Data;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public class ArtistRepository : Genaricepository<Artist>, IArtistRepository
    {
        private readonly MusifyDbContext _dbContext;

        public ArtistRepository(MusifyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Artist> GetArtistWithAlbum(Guid id)
        {
            return await _dbContext.Artists
                .Include(x => x.Albums)
                .FirstOrDefaultAsync(x => x.Id == id.ToString())
                ?? throw new ArgumentNullException("Artist Not found");
        }

        public async Task<Artist> GetArtistWithSongs(Guid id)
        {
            return await _dbContext.Artists
                .Include(x => x.Songs)
                .FirstOrDefaultAsync(x => x.Id == id.ToString())
                ?? throw new ArgumentNullException("Artist Not found");
        }
    }
}
