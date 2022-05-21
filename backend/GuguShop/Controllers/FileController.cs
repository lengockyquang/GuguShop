using GuguShop.GridFsApplication.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace GuguShop.Controllers;

[ApiController]
[Route("api/file")]
public class FileController : Controller
{
    private readonly IBaseMongoClient _baseMongoClient;
    private readonly GridFSBucketOptions _bucketOptions;
    public FileController(IBaseMongoClient baseMongoClient)
    {
        _baseMongoClient = baseMongoClient;
        _bucketOptions = new GridFSBucketOptions
        {
            BucketName = "sample",
            ChunkSizeBytes = 1048576, // 1MB
            WriteConcern = WriteConcern.WMajority,
            ReadPreference = ReadPreference.Secondary
        };
    }
    
    [HttpPost("upload-mongo")]
    [RequestSizeLimit(1024 * 1024 * 1024)]       //unit is bytes => 1gb
    public async Task<ActionResult> HandleUploadAction(IFormFile file)
    {
        var bucket = new GridFSBucket(_baseMongoClient.GetMongoDatabase(), _bucketOptions);
        await using var stream = new MemoryStream();
        await file.CopyToAsync(stream);
        var id = await bucket.UploadFromBytesAsync(file.FileName, stream.ToArray());
        return Ok(id);
    }
}