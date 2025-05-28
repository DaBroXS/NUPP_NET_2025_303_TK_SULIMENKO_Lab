using Gadgets.Infrastructure.DataContexts;
using Gadgets.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Gadgets.Infrastructure.Repositories;

public class ScreenRepository : Repository<ScreenModel>
{
    public ScreenRepository(GadgetsContext context) : base(context)
    {
    }
    
    public override async Task<ScreenModel> GetByIdAsync(Guid id)
    {
        return await Entries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<IEnumerable<ScreenModel>> GetAllAsync()
    {
        return await Entries.ToListAsync();
    }
    
    public override async Task<IEnumerable<ScreenModel>> GetAllAsync(int page, int amount)
    {
        return await Entries
            .Skip(page * amount)
            .Take(amount)
            .ToListAsync();
    }

    public override async Task<bool> AddAsync(ScreenModel entity)
    {
        Entries.Add(entity);
        return await Context.SaveChangesAsync() > 0;
    }

    public override async Task<bool> Update(ScreenModel entity)
    {
        Entries.Update(entity);
        return await Context.SaveChangesAsync() > 0;
    }

    public override async Task<bool> Delete(ScreenModel entity)
    {
        Entries.Remove(entity);
        return await Context.SaveChangesAsync() > 0;
    }
}