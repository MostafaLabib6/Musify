using Musify.MVC.Models.Entities;

namespace Musify.MVC.Repositories
{
    public interface IAuthorRepository:IGenaricRepository<User>
    {
        public Task<User> GetAuthorFollowers(Guid id);
    }
}
