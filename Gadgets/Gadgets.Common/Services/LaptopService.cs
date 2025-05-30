using Gadgets.Common.Entities;

namespace Gadgets.Common.Services;

public class LaptopService : CrudService<Laptop>
{
    protected override Guid GetId(Laptop element)
    {
        return element.Id;
    }
}