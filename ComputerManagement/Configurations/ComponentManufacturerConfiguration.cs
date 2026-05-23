using ComputerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerManagement.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.HasKey(cm => cm.Id);
        builder.Property(cm => cm.Abbreviation).HasMaxLength(30).IsRequired();
        builder.Property(cm => cm.FullName).HasMaxLength(300).IsRequired();
        builder.Property(cm => cm.FoundationDate).HasColumnType("date").IsRequired();

        builder.ToTable("ComponentManufacturers");

        builder.HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer() { Id = 1, Abbreviation = "Intel", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturer() { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices, Inc.", FoundationDate = new DateOnly(1969, 5, 1) },
            new ComponentManufacturer() { Id = 3, Abbreviation = "NVIDIA", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) },
        });
    }
}
