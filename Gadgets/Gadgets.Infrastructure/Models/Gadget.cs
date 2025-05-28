
using System.ComponentModel.DataAnnotations;

namespace Gadgets.Infrastructure.Models;

public class Gadget
{
    [Key]
    public Guid Id { get; set; }
    
    [StringLength(100)]
    public string Brand { get; set; }
    
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public double Price { get; set; }
}