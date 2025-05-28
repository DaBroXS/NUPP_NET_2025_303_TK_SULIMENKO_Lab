using Gadgets.Common.Entities;

namespace Gadgets.Common.Services;

public class ScreenService : CrudService<Screen>
{
    protected override Guid GetId(Screen element)
    {
        return element.Id;
    }
}