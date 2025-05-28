using Gadgets.Common.Entities;

namespace Gadgets.Common.Services.Async;

public class LaptopAsyncService : AsyncCrudService<Laptop>
{
    protected override Guid GetId(Laptop element)
    {
        return element.Id;
    }
}