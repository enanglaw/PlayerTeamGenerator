namespace WebApi.Contracts.Persistence
{
    
    public interface IAsyncBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        
        Task UpdateAsync(int id, T entity);


        Task<bool> DeleteAsync(int id);
    }
}
