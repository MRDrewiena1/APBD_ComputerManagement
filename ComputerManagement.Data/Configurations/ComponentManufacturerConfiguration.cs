using ComputerManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerManagement.Data.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.ToTable("ComponentManufacturers");

        builder.HasKey(cm => cm.Id);
        builder.Property(cm => cm.Id).ValueGeneratedOnAdd();

        builder.Property(cm => cm.Abbreviation)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(cm => cm.FullName)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(cm => cm.FoundationDate)
            .IsRequired();

        builder.HasData(
            new ComponentManufacturer { Id = 1, Abbreviation = "Intel", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturer { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices, Inc.", FoundationDate = new DateOnly(1969, 5, 1) },
            new ComponentManufacturer { Id = 3, Abbreviation = "NVIDIA", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) }
        );
    }
}
