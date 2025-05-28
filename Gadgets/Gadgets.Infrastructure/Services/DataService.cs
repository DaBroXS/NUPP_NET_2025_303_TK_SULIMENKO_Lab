using System.Collections;
using Gadgets.Common.Contracts;

namespace Gadgets.Infrastructure.Services;

public class DataService<T> : IAsyncCrudService<T> where T : class
{
    public DataService(IRepository<T> repository)
    {
        Repository = repository;
    }
    
    public IRepository<T> Repository { get; }
    

    public Task<bool> CreateAsync(T element)
    {
        return Repository.AddAsync(element);
    }

    public Task<T> ReadAsync(Guid id)
    {
        return Repository.GetByIdAsync(id);
    }

    public Task<IEnumerable<T>> ReadAllAsync()
    {
        return Repository.GetAllAsync();
    }

    public Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
    {
        return Repository.GetAllAsync(page, amount);
    }

    public Task<bool> UpdateAsync(T element)
    {
        return Repository.Update(element);
    }

    public Task<bool> RemoveAsync(T element)
    {
        return Repository.Delete(element);
    }

    public Task Load(string path)
    {
        throw new NotImplementedException();
    }

    public Task Save(string path)
    {
        throw new NotImplementedException();
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}