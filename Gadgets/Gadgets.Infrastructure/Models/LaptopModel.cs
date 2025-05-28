
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gadgets.Infrastructure.Models;

public class LaptopModel : GadgetModel
{
    [Range(0, int.MaxValue)]
    public int Ram { get; set; }
    
    [Range(0, Double.MaxValue)]
    public double ScreenSize { get; set; }
    
    public bool HasTouchscreen { get; set; }
    
    [ForeignKey(nameof(LaptopModel))]
    public ScreenModel ScreenModel { get; set; }
}