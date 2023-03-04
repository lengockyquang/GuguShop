using GuguShop.Constants;
using GuguShop.Infrastructure.Utility;
using Microsoft.AspNetCore.Mvc;

namespace GuguShop.Controllers.Common;

//[Authorize]
[ApiController]
[Route("api/file")]
public class FileController : Controller
{
    private readonly IFileService _fileService;
    private readonly IMongoFileService _mongoFileService;
    private readonly ILogger<FileController> _logger;
    public FileController(IFileService fileService, ILogger<FileController> logger, IMongoFileService mongoFileService)
    {
        _fileService = fileService;
        _logger = logger;
        _mongoFileService = mongoFileService;
    }

    [HttpPost("upload-mongo")]
    [RequestSizeLimit(CommonConstants.RequestSizeLimit)]
    public async Task<ActionResult> HandleUploadAction(IFormFile file, CancellationToken cancellationToken = default)
    {
       var result = await _mongoFileService.UploadAsync(file, cancellationToken);
       return Ok(result);
    }

    [HttpGet("download")]
    public async Task<ActionResult> HandleDownloadFileAction(Guid id,CancellationToken cancellationToken)
    {
        var result = await _mongoFileService.Download(id);
        return File(result, "image/png");
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