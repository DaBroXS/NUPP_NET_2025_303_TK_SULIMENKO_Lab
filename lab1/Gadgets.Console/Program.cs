using System;

public class Program
{
    static void Main()
    {
        // Створюємо екземпляри класів
        Laptop laptop = new Laptop("Dell", 1200.99, 16, 15.6, true);
        Smartphone phone = new Smartphone("Samsung", 899.99, "Android", 5000, 108);
        Screen screen = new Screen(27.0, "4K", "IPS");

        // Підписуємося на подію запуску ноутбука
        laptop.LaptopStarted += MessageHandler;

        // Вивід інформації
        laptop.ShowInfo();
        phone.ShowInfo();
        screen.DisplayInfo();

        // Виклик методу запуску ноутбука (спрацює подія)
        laptop.Start();

        // Використання статичного методу
        Gadget.ShowTotalGadgets();

        // Використання методу розширення
        laptop.Discount(10);
    }

    // Обробник події запуску ноутбука
    static void MessageHandler(string message)
    {
        Console.WriteLine($"[EVENT]: {message}");
    }
}
