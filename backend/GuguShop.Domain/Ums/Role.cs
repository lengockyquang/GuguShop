using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GuguShop.Domain.Ums;

public class Role: IdentityRole<Guid>
{
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; }
}