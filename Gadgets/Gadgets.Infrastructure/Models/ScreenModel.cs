
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gadgets.Infrastructure.Models;

public class ScreenModel
{
    [Key]
    public Guid Id { get; set; }
    
    [Range(0, Double.MaxValue)]
    public double Size { get; set; }
    
    [StringLength(16)]
    public string Resolution { get; set; }
    
    [StringLength(64)]
    public string PanelType { get; set; }
    
    [InverseProperty(nameof(ScreenModel))]
    public ICollection<LaptopModel> Laptops { get; set; } = new Collection<LaptopModel>();
}