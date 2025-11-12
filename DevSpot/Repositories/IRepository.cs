namespace DevSpot.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
    }
}
