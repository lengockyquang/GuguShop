using System;
using Microsoft.AspNetCore.Identity;

namespace GuguShop.Domain.Ums;

public class RoleClaim: IdentityRoleClaim<Guid>
{
    public Role Role { get; set; }
}