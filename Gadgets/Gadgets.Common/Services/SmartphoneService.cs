using Gadgets.Common.Entities;

namespace Gadgets.Common.Services;

public class SmartphoneService : CrudService<Smartphone>
{
    protected override Guid GetId(Smartphone element)
    {
        return element.Id;
    }
}