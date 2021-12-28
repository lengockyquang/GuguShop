using GuguShop.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Migrator
{
    public class MigratorDbContext: DbContext
    {
        public MigratorDbContext(DbContextOptions options): base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureEntities();
        }
    }
}