using ComputerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerManagement.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(c => c.Code);
        builder.Property(c => c.Code).HasColumnType("char(10)").IsRequired();
        builder.Property(c => c.Name).HasMaxLength(300).IsRequired();
        builder.Property(c => c.Description).HasColumnType("nvarchar(max)");
        builder.Property(c => c.ComponentManufacturersId).IsRequired();
        builder.Property(c => c.ComponentTypesId).IsRequired();

        builder.HasOne(c => c.Manufacturer)
            .WithMany(m => m.Components)
            .HasForeignKey(c => c.ComponentManufacturersId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.ComponentType)
            .WithMany(ct => ct.Components)
            .HasForeignKey(c => c.ComponentTypesId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Components");

        builder.HasData(new List<Component>()
        {
            new Component() { Code = "I9-14900K ", Name = "Intel Core i9-14900K", Description = "High-end desktop processor", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component() { Code = "RTX4090   ", Name = "NVIDIA GeForce RTX 4090", Description = "Top-tier gaming GPU", ComponentManufacturersId = 3, ComponentTypesId = 2 },
            new Component() { Code = "DDR5-32GB ", Name = "32GB DDR5 RAM Kit", Description = "High-speed memory module", ComponentManufacturersId = 2, ComponentTypesId = 3 },
        });
    }
}
