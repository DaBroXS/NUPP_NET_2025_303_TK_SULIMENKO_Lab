using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gadgets.Infrastructure.DataContexts;

public class GadgetsContextFactory: IDesignTimeDbContextFactory<GadgetsContext>
{
    public GadgetsContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=gadgets;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;")
            .Options;

        return new GadgetsContext(options);
    }
}