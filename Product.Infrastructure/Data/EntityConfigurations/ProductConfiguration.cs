using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyProduct.Domain.Models;

namespace MyProduct.Infrastructure.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.CategoryId)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
