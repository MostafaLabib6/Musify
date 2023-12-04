using Microsoft.EntityFrameworkCore;
using Musify.MVC.Data;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public class AuthorRepository : Genaricepository<User>, IAuthorRepository
    {
        private readonly MusifyDbContext _dbContext;

        public AuthorRepository(MusifyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetAuthorFollowers(Guid id)
        {
            return await _dbContext.Users
                .Include(x => x.Followers)
                .FirstOrDefaultAsync(x => x.Id == id.ToString())
                ?? throw new ArgumentNullException("Author not Found");
        }
    }
}
