using ComputerManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerManagement.Data.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.ToTable("ComponentTypes");

        builder.HasKey(ct => ct.Id);
        builder.Property(ct => ct.Id).ValueGeneratedOnAdd();

        builder.Property(ct => ct.Abbreviation)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(ct => ct.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
        );
    }
}
