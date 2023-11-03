using Musify.MVC.Data;
using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public class AuthorRepository : Genaricepository<Author>, IAuthorRepository
    {
        private readonly MusifyDbContext _dbContext;

        public AuthorRepository(MusifyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Author> GetAuthorFollowers(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
