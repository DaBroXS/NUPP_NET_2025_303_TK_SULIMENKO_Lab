
namespace Gadgets.Common.Entities;

// Клас Screen (не успадковується)
public class Screen
{
    public Guid Id { get; set; }
    public double Size { get; set; }
    public string Resolution { get; set; }
    public string PanelType { get; set; }

    // Конструктор
    public Screen(double size, string resolution, string panelType)
    {
        Id = Guid.NewGuid();
        Size = size;
        Resolution = resolution;
        PanelType = panelType;
    }

    // Метод
    public void DisplayInfo()
    {
        Console.WriteLine($"Screen: {Size} inches, Resolution: {Resolution}, Panel: {PanelType}");
    }
}