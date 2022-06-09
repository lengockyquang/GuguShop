using GuguShop.Infrastructure.Utility;

namespace GuguShop.Middlewares;

public class CustomJwtMiddleware
{
    private readonly RequestDelegate _next;

    public CustomJwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ICustomJwtGenerator jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var isValidToken = jwtUtils.ValidateCurrentToken(token);
        if (isValidToken)
        {
            // attach user to context on successful jwt validation
            //context.Items["User"] = userService.GetById(userId.Value);
            context.Items["UserName"] = "quang.le";
        }

        await _next(context);
    }
}