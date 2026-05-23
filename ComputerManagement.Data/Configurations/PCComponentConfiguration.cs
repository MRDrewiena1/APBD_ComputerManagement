using ComputerManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerManagement.Data.Configurations;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        builder.ToTable("PCComponents");

        // Composite primary key
        builder.HasKey(pc => new { pc.PCId, pc.ComponentCode });

        builder.Property(pc => pc.PCId).IsRequired();

        builder.Property(pc => pc.ComponentCode)
            .IsRequired()
            .HasColumnType("char(10)");

        builder.Property(pc => pc.Amount).IsRequired();

        builder.HasOne(pc => pc.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(pc => pc.PCId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pc => pc.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(pc => pc.ComponentCode)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new PCComponent { PCId = 1, ComponentCode = "I9-14900K", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "RTX4090  ", Amount = 2 },
            new PCComponent { PCId = 2, ComponentCode = "DDR5-32GB", Amount = 4 },
            new PCComponent { PCId = 3, ComponentCode = "I9-14900K", Amount = 2 },
            new PCComponent { PCId = 3, ComponentCode = "DDR5-32GB", Amount = 8 }
        );
    }
}
