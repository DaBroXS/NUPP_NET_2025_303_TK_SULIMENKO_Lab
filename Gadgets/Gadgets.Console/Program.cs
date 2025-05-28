using System;
using Gadgets.Common.Entities;
using Gadgets.Common.Extensions;
using Gadgets.Common.Services;
using Gadgets.Common.Services.Async;

public class Program
{
    static async Task Main()
    {
        LaptopAsyncService service = new();
        
        Parallel.For(0, 10000, async void (i) =>
        {
            try
            {
                var laptop = new Laptop("Test", Random.Shared.Next(1000, 10000), 8, 15.6, true);
                await service.CreateAsync(laptop);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        });

        var laptops = (await service.ReadAllAsync()).ToList();
        
        Console.WriteLine(laptops.Count);
        Console.WriteLine(laptops.Min(x => x.Price));
        Console.WriteLine(laptops.Max(x => x.Price));
        Console.WriteLine(laptops.Average(x => x.Price));
        
        await service.Save("laptops.json");
    }

}
