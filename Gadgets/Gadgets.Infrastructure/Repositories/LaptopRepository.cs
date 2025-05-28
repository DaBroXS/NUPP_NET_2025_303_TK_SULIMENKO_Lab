using Gadgets.Infrastructure.DataContexts;
using Gadgets.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Gadgets.Infrastructure.Repositories;

public class LaptopRepository : Repository<Laptop>
{
    public LaptopRepository(GadgetsContext context) : base(context)
    {
    }

    public override async Task<Laptop> GetByIdAsync(Guid id)
    {
        return await Entries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<IEnumerable<Laptop>> GetAllAsync()
    {
        return await Entries.ToListAsync();
    }

    public override async Task<IEnumerable<Laptop>> GetAllAsync(int page, int amount)
    {
        return await Entries
            .Skip(page * amount)
            .Take(amount)
            .ToListAsync();
    }

    public override async Task<bool> AddAsync(Laptop entity)
    {
        Entries.Add(entity);
        return await Context.SaveChangesAsync() > 0;
    }

    public override async Task<bool> Update(Laptop entity)
    {
        Entries.Update(entity);
        return await Context.SaveChangesAsync() > 0;
    }

    public override async Task<bool> Delete(Laptop entity)
    {
        Entries.Remove(entity);
        return await Context.SaveChangesAsync() > 0;
    }
}