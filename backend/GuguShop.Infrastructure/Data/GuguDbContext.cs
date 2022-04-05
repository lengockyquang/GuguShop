using GuguShop.Domain.Entities;
using GuguShop.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Infrastructure.Data
{
    public class GuguDbContext: DbContext
    {
        public GuguDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Product> Product { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureEntities();
        }
    }
}