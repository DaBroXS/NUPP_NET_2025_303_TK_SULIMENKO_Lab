using Gadgets.Common.Contracts;
using Gadgets.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Gadgets.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class
{
    public Repository(GadgetsContext context)
    {
        Context = context;
        Entries = Context.Set<T>();
    }
    
    public GadgetsContext Context { get; }
    public DbSet<T> Entries { get; }

    public abstract Task<T> GetByIdAsync(Guid id);

    public abstract Task<IEnumerable<T>> GetAllAsync();

    public abstract Task<IEnumerable<T>> GetAllAsync(int page, int amount);

    public abstract Task<bool> AddAsync(T entity);

    public abstract Task<bool> Update(T entity);

    public abstract Task<bool> Delete(T entity);
}