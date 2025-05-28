
using System.ComponentModel.DataAnnotations;

namespace Gadgets.Infrastructure.Models;

public class SmartphoneModel : GadgetModel
{
    [StringLength(16)]
    public string OperatingSystem { get; set; }
    
    [Range(0, int.MaxValue)]
    public int BatteryCapacity { get; set; }
    
    [Range(0, int.MaxValue)]
    public int CameraResolution { get; set; }
}