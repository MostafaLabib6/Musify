using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public interface IAuthorRepository:IGenaricRepository<Author>
    {
        public Task<Author> GetAuthorFollowers(Guid id);
    }
}
