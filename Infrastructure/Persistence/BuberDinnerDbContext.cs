using System.Reflection;

using Domain.Menu;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class BuberDinnerDbContext : DbContext
{
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options)
        : base(options)
    { }

    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(BuberDinnerDbContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }
}