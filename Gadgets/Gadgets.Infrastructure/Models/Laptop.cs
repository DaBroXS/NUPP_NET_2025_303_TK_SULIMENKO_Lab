
using System.ComponentModel.DataAnnotations;

namespace Gadgets.Infrastructure.Models;

public class Laptop : Gadget
{
    [Range(0, int.MaxValue)]
    public int Ram { get; set; }
    
    [Range(0, Double.MaxValue)]
    public double ScreenSize { get; set; }
    
    public bool HasTouchscreen { get; set; }
    
    public Screen Screen { get; set; }
}