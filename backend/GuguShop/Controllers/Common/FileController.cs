using GuguShop.Constants;
using GuguShop.GridFsApplication.Services;
using GuguShop.Infrastructure.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers.Common;

//[Authorize]
[ApiController]
[Route("api/file")]
public class FileController : Controller
{
    private readonly IBaseMongoClient _baseMongoClient;
    private readonly IFileService _fileService;
    private readonly ILogger<FileController> _logger;
    public FileController(IBaseMongoClient baseMongoClient, IFileService fileService, ILogger<FileController> logger)
    {
        _baseMongoClient = baseMongoClient;
        _fileService = fileService;
        _logger = logger;
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

    [HttpPost("upload-physical")]
    [RequestSizeLimit(CommonConstants.RequestSizeLimit)]
    public async Task<ActionResult> HandleUpdatePhysicalAction(IFormFile file, CancellationToken cancellationToken)
    {
        return Ok(await _fileService.UploadAsync(file));
    }

    [HttpGet("get-physical")]
    public async Task<ActionResult> HandleGetFileAction(Guid id, CancellationToken cancellationToken)
    {
        var (location, extension) = await _fileService.GetFileLocation(id);
        var filePath = $"{location}{extension}";
        _logger.LogInformation(filePath);
        return PhysicalFile(location, "application/octet-stream", Path.GetFileName(filePath));
    }
}