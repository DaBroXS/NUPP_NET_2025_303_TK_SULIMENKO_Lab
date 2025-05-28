using Gadgets.Common.Entities;

namespace Gadgets.Common.Services.Async;

public class ScreenAsyncService : AsyncCrudService<Screen>
{
    protected override Guid GetId(Screen element)
    {
        return element.Id;
    }
}