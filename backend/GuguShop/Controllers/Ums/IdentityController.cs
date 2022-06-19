using GuguShop.Application.Dto;
using GuguShop.Domain.Ums;
using GuguShop.Infrastructure.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers.Ums;

[AllowAnonymous]
[Route("/api/identity")]
public class IdentityController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<IdentityController> _logger;
    private readonly IAuthUser _authUser;
    public IdentityController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<IdentityController> logger, IAuthUser authUser)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
        _authUser = authUser;
    }

    [HttpPost("login")]
    public async Task<IActionResult> HandleLoginAction([FromBody] LoginForm loginForm)
    {
        var result = await _signInManager.PasswordSignInAsync(
            loginForm.UserName,
            loginForm.Password,
            loginForm.RememberMe,
            false);
        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest("Username or password is incorrect");
    }

    [HttpGet("check-login")]
    public IActionResult HandleCheckLoginAction()
    {
        return Ok(_authUser.IsAuthenticated);
    }

    [HttpGet("logout")]
    public async Task<IActionResult> HandleLogoutAction()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> HandleRegisterAction(RegisterForm registerForm)
    {
        var user = new User() { UserName = registerForm.UserName, Email = registerForm.Email };
        var result = await _userManager.CreateAsync(user, registerForm.Password);
        if (result.Succeeded)
        {
            return Ok();
        }
        return Ok(result.Errors);
    }
}