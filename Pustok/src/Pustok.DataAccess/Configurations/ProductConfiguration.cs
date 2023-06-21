using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pustok.Core.Entities;

namespace Pustok.DataAccess.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).IsRequired(true).HasMaxLength(300);
        builder.Property(p => p.Price).IsRequired(true).HasColumnType("decimal(10,2)");
        builder.Property(p => p.IsDeleted).HasDefaultValue(false);

        builder.HasOne(p => p.Category).WithMany(c => c.Products);
        builder.HasCheckConstraint("CK_Product_Price", "Price >= 0");
    }
}