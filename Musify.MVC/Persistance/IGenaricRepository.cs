namespace Musify.MVC.Repositories
{
    public interface IGenaricRepository<T> where T : class
    {
        public Task<T> Get(Guid id);
        public Task<IReadOnlyList<T>> GetAll();
        public Task<int> Save();

        // in memory 
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(Guid id);
    }
}
