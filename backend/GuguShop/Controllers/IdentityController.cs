using GuguShop.Application.Dto;
using GuguShop.Infrastructure.Utility;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers;

[Route("/api/identity")]
public class IdentityController : Controller
{
    private readonly ICustomJwtGenerator _customJwtGenerator;
    public IdentityController(ICustomJwtGenerator customJwtGenerator)
    {
        _customJwtGenerator = customJwtGenerator;
    }
    
    [HttpPost("login")]
    public IActionResult HandleLoginAction(LoginForm loginForm)
    {
        var token = _customJwtGenerator.GenerateToken(loginForm.UserName);
        return Ok(token);
    }

    [HttpGet("check-login")]
    public IActionResult HandleCheckLoginAction(string token)
    {
        var isValid = _customJwtGenerator.ValidateCurrentToken(token);
        return isValid ? Ok("Success") : Unauthorized();
    }
}