using ComputerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerManagement.Configurations;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Weight).IsRequired();
        builder.Property(p => p.Warranty).IsRequired();
        builder.Property(p => p.CreatedAt).HasColumnType("datetime2").IsRequired();
        builder.Property(p => p.Stock).IsRequired();

        builder.ToTable("PCs");

        builder.HasData(new List<PC>()
        {
            new PC() { Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = DateTime.Parse("2026-05-08T09:00:00"), Stock = 5 },
            new PC() { Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = DateTime.Parse("2026-04-15T13:30:00"), Stock = 12 },
            new PC() { Id = 3, Name = "Workstation Ultra", Weight = 18.0f, Warranty = 48, CreatedAt = DateTime.Parse("2026-03-01T08:00:00"), Stock = 3 },
        });
    }
}
