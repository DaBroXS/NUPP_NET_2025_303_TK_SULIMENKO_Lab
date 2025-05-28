
namespace Gadgets.Common.Entities;

// Клас Smartphone, успадкований від Gadget
public class Smartphone : Gadget
{
    public string OperatingSystem { get; set; }
    public int BatteryCapacity { get; set; }
    public int CameraResolution { get; set; }

    // Конструктор
    public Smartphone(string brand, double price, string os, int battery, int camera)
        : base(brand, price)
    {
        OperatingSystem = os;
        BatteryCapacity = battery;
        CameraResolution = camera;
    }

    // Перевизначений метод
    public override void ShowInfo()
    {
        Console.WriteLine($"Smartphone: {Brand}, OS: {OperatingSystem}, Battery: {BatteryCapacity}mAh, Camera: {CameraResolution}MP");
    }
}