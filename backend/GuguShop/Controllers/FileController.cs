using GuguShop.Constants;
using GuguShop.GridFsApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers;

[ApiController]
[Route("api/file")]
public class FileController : Controller
{
    private readonly IBaseMongoClient _baseMongoClient;
    public FileController(IBaseMongoClient baseMongoClient)
    {
        _baseMongoClient = baseMongoClient;
    }
    
    [HttpPost("upload-mongo")]
    [RequestSizeLimit(CommonConstants.RequestSizeLimit)]
    public async Task<ActionResult> HandleUploadAction(IFormFile file, CancellationToken cancellationToken = default)
    {
        await using var stream = new MemoryStream();
        await file.CopyToAsync(stream, cancellationToken);
        var id = await _baseMongoClient.UploadFromBytesAsync(file.FileName, stream.ToArray(), cancellationToken);
        return Ok(id);
    }
}