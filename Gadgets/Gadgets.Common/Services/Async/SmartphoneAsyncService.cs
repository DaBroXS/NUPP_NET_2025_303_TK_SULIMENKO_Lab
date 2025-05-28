using Gadgets.Common.Entities;

namespace Gadgets.Common.Services.Async;

public class SmartphoneAsyncService : AsyncCrudService<Smartphone>
{
    protected override Guid GetId(Smartphone element)
    {
        return element.Id;
    }
}