using ComputerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerManagement.Configurations;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        builder.HasKey(pc => new { pc.PCId, pc.ComponentCode });
        builder.Property(pc => pc.ComponentCode).HasColumnType("char(10)").IsRequired();
        builder.Property(pc => pc.Amount).IsRequired();

        builder.HasOne(pc => pc.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(pc => pc.PCId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pc => pc.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(pc => pc.ComponentCode)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("PCComponents");

        builder.HasData(new List<PCComponent>()
        {
            new PCComponent() { PCId = 1, ComponentCode = "I9-14900K ", Amount = 1 },
            new PCComponent() { PCId = 1, ComponentCode = "RTX4090   ", Amount = 2 },
            new PCComponent() { PCId = 2, ComponentCode = "DDR5-32GB ", Amount = 4 },
            new PCComponent() { PCId = 3, ComponentCode = "I9-14900K ", Amount = 2 },
            new PCComponent() { PCId = 3, ComponentCode = "DDR5-32GB ", Amount = 8 },
        });
    }
}
