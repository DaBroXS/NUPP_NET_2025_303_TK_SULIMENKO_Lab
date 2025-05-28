namespace Gadgets.Common.Contracts;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(int page, int amount);
    Task<bool> AddAsync(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(T entity);
}