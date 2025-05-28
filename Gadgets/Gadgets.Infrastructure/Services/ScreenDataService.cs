using Gadgets.Common.Contracts;
using Gadgets.Infrastructure.Models;

namespace Gadgets.Infrastructure.Services;

public class ScreenDataService : DataService<Screen>
{
    public ScreenDataService(IRepository<Screen> repository) : base(repository)
    {
    }
}