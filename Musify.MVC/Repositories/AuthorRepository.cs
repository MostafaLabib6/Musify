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
        public Task<User> GetAuthorFollowers(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
