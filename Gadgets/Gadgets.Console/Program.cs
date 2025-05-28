using System;
using Gadgets.Common.Entities;
using Gadgets.Common.Extensions;
using Gadgets.Common.Services;

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
        
        LaptopService service = new LaptopService();
        service.Load("laptops.json");
        
        service.Create(laptop);
        
        Laptop found = service.Read(laptop.Id);
        
        if (found != null)
            found.ShowInfo();

        Laptop toUpdate = new Laptop("Dell", 2300.99, 8, 13, false);
        toUpdate.Id = laptop.Id;
        
        service.Update(toUpdate);

        Console.WriteLine("Всі ноутбуки: ");
        foreach (var element in service.ReadAll())
        {
            element.ShowInfo();
        }
        
        service.Remove(laptop);
        
        service.Save("laptops.json");
    }

    // Обробник події запуску ноутбука
    static void MessageHandler(string message)
    {
        Console.WriteLine($"[EVENT]: {message}");
    }
}
