using Gadgets.Common.Contracts;
using Gadgets.Infrastructure.Models;

namespace Gadgets.Infrastructure.Services;

public class LaptopDataService : DataService<Laptop>
{
    public LaptopDataService(IRepository<Laptop> repository) : base(repository)
    {
    }
}