
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Gadgets.Infrastructure.Models;

public class Screen
{
    [Key]
    public Guid Id { get; set; }
    
    [Range(0, Double.MaxValue)]
    public double Size { get; set; }
    
    [StringLength(16)]
    public string Resolution { get; set; }
    
    [StringLength(64)]
    public string PanelType { get; set; }
    
    public ICollection<Laptop> Laptops { get; set; } = new Collection<Laptop>();
}