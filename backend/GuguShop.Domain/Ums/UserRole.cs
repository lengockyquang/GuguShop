using System;
using Microsoft.AspNetCore.Identity;

namespace GuguShop.Domain.Ums;

public class UserRole: IdentityUserRole<Guid>
{
    public User User { get; set; }

    public Role Role { get; set; }
}