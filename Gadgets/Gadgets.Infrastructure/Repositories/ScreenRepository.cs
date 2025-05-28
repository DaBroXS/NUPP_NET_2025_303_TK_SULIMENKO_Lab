using Gadgets.Infrastructure.DataContexts;
using Gadgets.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Gadgets.Infrastructure.Repositories;

public class ScreenRepository : Repository<Screen>
{
    public ScreenRepository(GadgetsContext context) : base(context)
    {
    }
    
    public override async Task<Screen> GetByIdAsync(Guid id)
    {
        return await Entries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<IEnumerable<Screen>> GetAllAsync()
    {
        return await Entries.ToListAsync();
    }
    
    public override async Task<IEnumerable<Screen>> GetAllAsync(int page, int amount)
    {
        return await Entries
            .Skip(page * amount)
            .Take(amount)
            .ToListAsync();
    }

    public override async Task<bool> AddAsync(Screen entity)
    {
        Entries.Add(entity);
        return await Context.SaveChangesAsync() > 0;
    }

    public override async Task<bool> Update(Screen entity)
    {
        Entries.Update(entity);
        return await Context.SaveChangesAsync() > 0;
    }

    public override async Task<bool> Delete(Screen entity)
    {
        Entries.Remove(entity);
        return await Context.SaveChangesAsync() > 0;
    }
}