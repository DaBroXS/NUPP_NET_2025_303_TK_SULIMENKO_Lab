using Gadgets.Infrastructure.DataContexts;
using Gadgets.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Gadgets.Infrastructure.Repositories;

public class LaptopRepository : Repository<LaptopModel>
{
    public LaptopRepository(GadgetsContext context) : base(context)
    {
    }

    public override async Task<LaptopModel> GetByIdAsync(Guid id)
    {
        return await Entries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<IEnumerable<LaptopModel>> GetAllAsync()
    {
        return await Entries.ToListAsync();
    }

    public override async Task<IEnumerable<LaptopModel>> GetAllAsync(int page, int amount)
    {
        return await Entries
            .Skip(page * amount)
            .Take(amount)
            .ToListAsync();
    }

    public override async Task<bool> AddAsync(LaptopModel entity)
    {
        Entries.Add(entity);
        return await Context.SaveChangesAsync() > 0;
    }

    public override async Task<bool> Update(LaptopModel entity)
    {
        Entries.Update(entity);
        return await Context.SaveChangesAsync() > 0;
    }

    public override async Task<bool> Delete(LaptopModel entity)
    {
        Entries.Remove(entity);
        return await Context.SaveChangesAsync() > 0;
    }
}