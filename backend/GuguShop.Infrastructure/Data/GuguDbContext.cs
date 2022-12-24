using System;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Ums;
using GuguShop.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuguShop.Infrastructure.Data
{
    public class GuguDbContext:  IdentityDbContext<
        User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public GuguDbContext()
        {

        }
        public GuguDbContext(DbContextOptions options): base(options)
        {
        }
        public override DbSet<User> Users { get; set; }
        public override DbSet<Role> Roles { get; set; }
        public override DbSet<UserClaim> UserClaims { get; set; }
        public override DbSet<RoleClaim> RoleClaims { get; set; }
        public override DbSet<UserToken> UserTokens { get; set; }
        public override DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureEntities();
            modelBuilder.ConfigureUmsEntities();
            modelBuilder.ConfigureFileEntities();
        }
    }
}