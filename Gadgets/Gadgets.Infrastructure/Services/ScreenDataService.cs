using Gadgets.Common.Contracts;
using Gadgets.Infrastructure.Models;

namespace Gadgets.Infrastructure.Services;

public class ScreenDataService : DataService<ScreenModel>
{
    public ScreenDataService(IRepository<ScreenModel> repository) : base(repository)
    {
    }
}