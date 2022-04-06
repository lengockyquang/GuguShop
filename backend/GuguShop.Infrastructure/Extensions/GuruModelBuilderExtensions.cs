using GuguShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Infrastructure.Extensions
{
    public static class GuruModelBuilderExtensions
    {
        public static void ConfigureEntities(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).IsRequired().HasMaxLength(100);
                e.Property(x => x.Name).IsRequired();

                e.HasIndex(x => x.Code).IsUnique();
                e.HasOne(x => x.Manufacturer)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.ManufacturerId);
                e.HasOne(x => x.Category)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.CategoryId);
            });

            modelBuilder.Entity<Manufacturer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).IsRequired().HasMaxLength(100);
                e.Property(x => x.Name).IsRequired();
                e.Property(x => x.Address).IsRequired();
                e.Property(x => x.Phone).IsRequired();

                e.HasIndex(x => x.Code).IsUnique();
                e.HasMany(x => x.Products)
                    .WithOne(x => x.Manufacturer);
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).IsRequired().HasMaxLength(100);
                e.HasIndex(x => x.Code).IsUnique();
                e.Property(x => x.Name).IsRequired();
                e.HasMany(x => x.Products)
                    .WithOne(x => x.Category);
            });
        }
    }
}