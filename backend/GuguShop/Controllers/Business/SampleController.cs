﻿using GuguShop.Infrastructure.Exceptions;
using GuguShop.Infrastructure.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers.Business;

[Route("api/sample")]
public class SampleController: Controller
{
    private readonly ICryptoService _cryptoService;
    public SampleController(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
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

    private static async Task<int> GetRandomInteger()
    {
        return await Task.FromResult(new Random().Next());
    }

}