using System;
using Gadgets.Common.Entities;
using Gadgets.Infrastructure.DataContexts;
using Gadgets.Infrastructure.DataContexts.Extensions;
using Gadgets.Infrastructure.Repositories;
using Gadgets.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static async Task Main()
    {
        var options = new DbContextOptionsBuilder()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=gadgets;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;")
            //.UseMongoDB("mongodb+srv://maks70393:fif6iY6Cw11Mf5bc@cluster0.vhnawve.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0", "gadgets")
            .Options;
        
        var context = new GadgetsContext(options);

        var repository = new LaptopRepository(context);
        var service = new LaptopDataService(repository);
        
        var laptop = new Laptop("Dell", 1200.99, 16, 15.6, true).ToModel();
        laptop.Screen = new Screen(13.3, "1920x1080", "LED").ToModel();
        
        await service.CreateAsync(laptop);
        
        var found = await service.ReadAsync(laptop.Id);
        
        if (found != null)
            Console.WriteLine("Ноутбук знайдено");
        
        var toUpdate = new Laptop("Dell", 2300.99, 8, 13, false).ToModel();
        toUpdate.Id = laptop.Id;
        
        await service.UpdateAsync(toUpdate);
        
        Console.WriteLine("Всі ноутбуки: ");
        foreach (var element in await service.ReadAllAsync())
        {
            element.FromModel().ShowInfo();
        }
        
        await service.RemoveAsync(laptop);
    }

}
