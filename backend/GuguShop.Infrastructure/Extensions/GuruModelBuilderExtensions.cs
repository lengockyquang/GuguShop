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
                e.Property(x => x.Code).IsRequired();
                e.Property(x => x.Name).IsRequired();

                e.HasIndex(x => x.Code).IsUnique();
            });
        }
    }
}