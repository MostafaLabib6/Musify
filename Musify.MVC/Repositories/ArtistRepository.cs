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
        public Task<Artist> GetArtistWithAlbum(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> GetArtistWithSongs(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
