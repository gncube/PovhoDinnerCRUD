using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class PovhoDinnerDbContext : DbContext
{
    public PovhoDinnerDbContext(DbContextOptions<PovhoDinnerDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PovhoDinnerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
