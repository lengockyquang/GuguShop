using GuguShop.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Infrastructure.Data
{
    public class GuguDbContext: DbContext
    {
        public GuguDbContext(DbContextOptions options): base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureEntities();
        }
    }
}