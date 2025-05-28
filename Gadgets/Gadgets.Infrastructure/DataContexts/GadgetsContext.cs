using Gadgets.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gadgets.Infrastructure.DataContexts;

public class GadgetsContext : IdentityDbContext<IdentityUser>
{
    public DbSet<LaptopModel> Laptops { get; set; }
    public DbSet<ScreenModel> Screens { get; set; }
    public DbSet<SmartphoneModel> Smartphones { get; set; }
    
    public GadgetsContext(DbContextOptions options) : base(options)
    {
    }
}