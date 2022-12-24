using GuguShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Infrastructure.Extensions
{
    public static class FileConfiguration
    {
        private const string FILE_SCHEMA_NAME = "file";
        public static void ConfigureFileEntities(this ModelBuilder builder)
        {
            builder.Entity<FileEntity>(entity =>
            {
                entity.ToTable(nameof(FileEntity), FILE_SCHEMA_NAME);
                entity.HasKey(x => x.Id);
            });
        }

    }
}
