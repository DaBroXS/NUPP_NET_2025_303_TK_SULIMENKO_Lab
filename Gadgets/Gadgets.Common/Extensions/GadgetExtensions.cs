
// Метод розширення для класу Gadget

using Gadgets.Common.Entities;

namespace Gadgets.Common.Extensions;

public static class GadgetExtensions
{
    public static void Discount(this Gadget gadget, double percent)
    {
        gadget.Price -= gadget.Price * (percent / 100);
        Console.WriteLine($"{gadget.Brand} new price after {percent}% discount: {gadget.Price}$");
    }
}