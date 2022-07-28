using GuguShop.Caching.Interfaces;
using GuguShop.Infrastructure.Exceptions;
using GuguShop.Infrastructure.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace GuguShop.Controllers.Business;

[Route("api/sample")]
public class SampleController: Controller
{
    private readonly ICryptoService _cryptoService;
    private readonly IGuguCache _guguCache;
    public SampleController(ICryptoService cryptoService, IGuguCache guguCache)
    {
        _cryptoService = cryptoService;
        _guguCache = guguCache;
    }

    [HttpGet("encrypt")]
    public IActionResult HandleEncryptAction([FromQuery]string cipher, [FromQuery]string key)
    {
        var encrypt = _cryptoService.Encrypt(cipher, key);
        return Ok(encrypt);
    }

    [HttpGet("decrypt")]
    public IActionResult HandleDecryptAction([FromQuery] string encrypt, [FromQuery]string key)
    {
        var cipher = _cryptoService.Decrypt(encrypt, key);
        return Ok(cipher);
    }

    [HttpGet("get-rand-number")]
    public IActionResult HandleGetRandomInteger()
    {
        var value = GetRandomInteger(); 
        return Ok(value.Result);
    }

    [HttpGet("test-redis")]
    public IActionResult HandleTestRedis()
    {
        return Ok(_guguCache.GetStatus());
    }

    private static async Task<int> GetRandomInteger()
    {
        return await Task.FromResult(new Random().Next());
    }

}