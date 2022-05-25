using GuguShop.Infrastructure.Utility;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers;

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

    [HttpGet("test-exception")]
    public async Task<IActionResult> HandleTestException()
    {
        var allTasks = Task.WhenAll(new[]
        {
            GetExceptionAsync("Task 1"),
            NormalTask("Task 2"),
            GetExceptionAsync("Task 3"),
        }); 
        try
        {
            await allTasks;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: "+ex.Message);
            if (allTasks.Exception != null)
            {
                foreach (var childTaskException in allTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine("Child exception: "+childTaskException.Message);
                }    
            }
        }
        return Ok();
    }

    private static async Task NormalTask(string taskName)
    {
        await Task.Delay(5000);
        Console.WriteLine(taskName+ " works!");
    }

    private static async Task GetExceptionAsync(string taskName)
    {
        await Task.Delay(5000);
        throw new Exception("Exception is from " + taskName);
    }
    
}