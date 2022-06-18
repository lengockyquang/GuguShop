using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GuguShop.Domain.Ums
{
    public class User: IdentityUser<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}