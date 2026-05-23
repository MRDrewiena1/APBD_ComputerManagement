using ComputerManagement.Data.Configurations;
using ComputerManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerManagement.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PCConfiguration());
        modelBuilder.ApplyConfiguration(new ComponentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ComponentManufacturerConfiguration());
        modelBuilder.ApplyConfiguration(new ComponentConfiguration());
        modelBuilder.ApplyConfiguration(new PCComponentConfiguration());
    }
}
