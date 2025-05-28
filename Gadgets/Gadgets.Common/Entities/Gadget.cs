

namespace Gadgets.Common.Entities;

// Базовий клас Gadget
public class Gadget
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }

    // Статичне поле для підрахунку створених гаджетів
    public static int TotalGadgets;

    // Статичний конструктор
    static Gadget()
    {
        TotalGadgets = 0;
        Console.WriteLine("Статичний конструктор Gadget викликано!");
    }

    // Конструктор
    public Gadget(string brand, double price)
    {
        Id = Guid.NewGuid();
        Brand = brand;
        Price = price;
        TotalGadgets++;
    }

    // Віртуальний метод
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Gadget: {Brand}, Price: {Price}$");
    }

    // Статичний метод
    public static void ShowTotalGadgets()
    {
        Console.WriteLine($"Total gadgets created: {TotalGadgets}");
    }
}