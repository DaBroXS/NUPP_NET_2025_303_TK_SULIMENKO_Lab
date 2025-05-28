using Gadgets.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Gadgets.Infrastructure.DataContexts;

public class GadgetsContext : DbContext
{
    public DbSet<Laptop> Laptops { get; set; }
    public DbSet<Screen> Screens { get; set; }
    public DbSet<Smartphone> Smartphones { get; set; }
    
    public GadgetsContext(DbContextOptions options) : base(options)
    {
    }
}