using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence;
public class PovhoDinnerDbContextFactory : IDesignTimeDbContextFactory<PovhoDinnerDbContext>
{
    public PovhoDinnerDbContext CreateDbContext(string[] args)
    {
        var home = Environment.GetEnvironmentVariable("HOME") ?? "";
        var databasePath = Path.Combine(home, "PovhoDinnerDb.sqlite");

        var optionsBuilder = new DbContextOptionsBuilder<PovhoDinnerDbContext>();
        //var connectionString = "Server=localhost;Database=PovhoDinnerDb;User Id=sa;Password=admin1234*";
        //optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseSqlite($"Data Source={databasePath}");

        return new PovhoDinnerDbContext(optionsBuilder.Options);
    }
}
