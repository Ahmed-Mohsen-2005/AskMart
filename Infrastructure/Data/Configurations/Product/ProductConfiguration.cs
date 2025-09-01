using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Products;

namespace Infrastructure.Data.Configurations.ProductConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ProductDescription).IsRequired().HasMaxLength(500);
            builder.Property(p => p.ProductPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.StockQuantity).IsRequired();
        }
    }
}
