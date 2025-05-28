using Gadgets.Common.Contracts;
using Gadgets.Infrastructure.Models;

namespace Gadgets.Infrastructure.Services;

public class LaptopDataService : DataService<LaptopModel>
{
    public LaptopDataService(IRepository<LaptopModel> repository) : base(repository)
    {
    }
}