using ComputerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerManagement.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.HasKey(ct => ct.Id);
        builder.Property(ct => ct.Abbreviation).HasMaxLength(30).IsRequired();
        builder.Property(ct => ct.Name).HasMaxLength(150).IsRequired();

        builder.ToTable("ComponentTypes");

        builder.HasData(new List<ComponentType>()
        {
            new ComponentType() { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType() { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType() { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" },
        });
    }
}
