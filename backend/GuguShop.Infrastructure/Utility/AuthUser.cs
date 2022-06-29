using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace GuguShop.Infrastructure.Utility;

public class AuthUser: IAuthUser
{
    private readonly IHttpContextAccessor _accessor;
    private readonly ClaimsPrincipal _principalAccessor;
    public AuthUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
        _principalAccessor = accessor.HttpContext?.User ?? new ClaimsPrincipal();;
    }

    public bool IsAuthenticated => _principalAccessor.Identity is { IsAuthenticated: true };
    public string UserName => _principalAccessor.Identity.Name;
    public ClaimsPrincipal ClaimsPrincipal => _principalAccessor;
}