using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using GuguShop.GridFsApplication.Services;
using GuguShop.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GuguShop.Infrastructure.Utility
{
    public class MongoFileService : IMongoFileService
    {
        private readonly IBaseMongoClient _baseMongoClient;
        private readonly IFileRepository _fileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public MongoFileService(IBaseMongoClient baseMongoClient, IFileRepository fileRepository, IUnitOfWork unitOfWork, ILogger<MongoFileService> logger)
        {
            _baseMongoClient = baseMongoClient;
            _fileRepository = fileRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> Download(Guid id)
        {
            var fileLocation = await GetFileLocation(id);
            return await _baseMongoClient.DownloadFromBytesAsyns(fileLocation.Item1);
        }

        public async Task<Tuple<string, string>> GetFileLocation(Guid id)
        {
            var fileEntity = await _fileRepository.Get(id);
            if (fileEntity == null)
            {
                _logger.LogInformation("Can not find file entity with id {0}", id);
                return new Tuple<string, string>(string.Empty, string.Empty);
            }
            return new Tuple<string, string>(fileEntity.Location, fileEntity.Extensions);
        }

        public Task<bool> IsExistAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> UploadAsync(IFormFile file, CancellationToken cancellationToken = default)
        {
            // save to db
            var fileEntity = new FileEntity("Mongo", file.FileName);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _fileRepository.Create(fileEntity);
                // write to location
                await using var stream = new MemoryStream();
                await file.CopyToAsync(stream, cancellationToken);
                var id = await _baseMongoClient.UploadFromBytesAsync(file.FileName, stream.ToArray(), cancellationToken);
                fileEntity.Location = id.ToString();
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return fileEntity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Upload mongo failed. {ex.Message} {ex.StackTrace}");
                await _unitOfWork.RollBackTransactionAsync();
                return Guid.Empty;
            }
        }
    }
}
