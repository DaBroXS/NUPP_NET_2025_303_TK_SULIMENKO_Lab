using Gadgets.Infrastructure.Models;

namespace Gadgets.Infrastructure.DataContexts.Extensions;

public static class EntitiesExtensions
{
    public static Laptop ToModel(this Gadgets.Common.Entities.Laptop entity)
    {
        return new Laptop()
        {
            Id = entity.Id,
            Brand = entity.Brand,
            Price = entity.Price,
            Ram = entity.Ram,
            ScreenSize = entity.ScreenSize,
            HasTouchscreen = entity.HasTouchscreen
        };
    }
    
    public static Screen ToModel(this Gadgets.Common.Entities.Screen entity)
    {
        return new Screen()
        {
            Id = entity.Id,
            PanelType = entity.PanelType,
            Resolution = entity.Resolution,
            Size = entity.Size
        };
    }
    
    public static Smartphone ToModel(this Gadgets.Common.Entities.Smartphone entity)
    {
        return new Smartphone()
        {
            Id = entity.Id,
            Brand = entity.Brand,
            Price = entity.Price,
            OperatingSystem = entity.OperatingSystem,
            BatteryCapacity = entity.BatteryCapacity,
            CameraResolution = entity.CameraResolution
        };
    }
    
    public static Gadgets.Common.Entities.Laptop FromModel(this Laptop model)
    {
        return new Gadgets.Common.Entities.Laptop(model.Brand, model.Price, model.Ram, model.ScreenSize, model.HasTouchscreen);
    }
    
    public static Gadgets.Common.Entities.Screen FromModel(this Screen model)
    {
        return new Gadgets.Common.Entities.Screen(model.Size, model.Resolution, model.PanelType);
    }
    
    public static Gadgets.Common.Entities.Smartphone FromModel(this Smartphone model)
    {
        return new Gadgets.Common.Entities.Smartphone(model.Brand, model.Price, model.OperatingSystem, model.BatteryCapacity, model.CameraResolution);
    }
}