
// Клас Laptop, успадкований від Gadget
public class Laptop : Gadget
{
    public int RAM { get; set; }
    public double ScreenSize { get; set; }
    public bool HasTouchscreen { get; set; }

    // Власний делегат для подій ноутбука
    public delegate void LaptopEventHandler(string message);

    // Подія, що використовує власний делегат
    public event LaptopEventHandler LaptopStarted;

    // Конструктор
    public Laptop(string brand, double price, int ram, double screenSize, bool hasTouchscreen)
        : base(brand, price)
    {
        RAM = ram;
        ScreenSize = screenSize;
        HasTouchscreen = hasTouchscreen;
    }

    // Перевизначений метод
    public override void ShowInfo()
    {
        Console.WriteLine($"Laptop: {Brand}, RAM: {RAM}GB, Screen: {ScreenSize} inches, Touch: {HasTouchscreen}");
    }

    // Метод запуску ноутбука
    public void Start()
    {
        Console.WriteLine($"{Brand} Laptop is starting...");
        LaptopStarted?.Invoke($"Laptop {Brand} has successfully started!"); // Виклик події
    }
}
