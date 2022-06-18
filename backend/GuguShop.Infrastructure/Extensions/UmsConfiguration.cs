using System;
using GuguShop.Domain.Ums;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Infrastructure.Extensions;

public static class UmsConfiguration
{
    private const string UMS_SCHEMA_NAME = "ums";

    public static void ConfigureUmsEntities(this ModelBuilder builder)
    {
        builder.Entity<User>(entity =>
        {
            entity.ToTable(nameof(User), UMS_SCHEMA_NAME);
            entity.HasKey(x => x.Id);
            entity.HasMany<UserRole>()
                .WithOne()
                .HasForeignKey(ur => ur.UserId).IsRequired();
        });
        
        builder.Entity<Role>(entity =>
        {
            entity.ToTable(nameof(Role), UMS_SCHEMA_NAME);
            entity.HasKey(r => r.Id);
            entity.HasIndex(r => r.NormalizedName).IsUnique();
            entity.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
            entity.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
            entity.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
        });
        
        builder.Entity<RoleClaim>(entity =>
        {
            entity.ToTable(nameof(RoleClaim), UMS_SCHEMA_NAME);
            entity.HasOne(x => x.Role)
                .WithMany(x => x.RoleClaims)
                .HasForeignKey(x => x.RoleId);
        });

        builder.Entity<UserClaim>(entity =>
        {
            entity.ToTable(nameof(UserClaim), UMS_SCHEMA_NAME);
        });
        
        builder.Entity<UserToken>(entity =>
        {
            entity.ToTable(nameof(UserToken), UMS_SCHEMA_NAME);
        });

        builder.Entity<UserLogin>(entity =>
        {
            entity.ToTable(nameof(UserLogin), UMS_SCHEMA_NAME);
        });

        builder.Entity<UserRole>(entity =>
        {
            entity.ToTable(nameof(UserRole), UMS_SCHEMA_NAME);

            entity.HasOne(d => d.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }
}