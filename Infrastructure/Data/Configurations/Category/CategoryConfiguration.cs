using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Products;
using Domain.Entities.Categories;

namespace Infrastructure.Data.Configurations.CategoryConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.Products).WithOne().HasForeignKey(p => p.CategoryId);
        }
        }
    }

