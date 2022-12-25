using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using GuguShop.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GuguShop.Infrastructure.Utility
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IUnitOfWork _unitOfWork;

        public FileService(IFileRepository fileRepository, ILogger<FileService> logger, IWebHostEnvironment hostingEnvironment, IUnitOfWork unitOfWork)
        {
            _fileRepository = fileRepository;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _unitOfWork = unitOfWork;
        }
        private readonly string _storedFolder = "StoredFiles";
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            var fileEntity = await _fileRepository.Get(id);
            if(fileEntity == null)
            {
                _logger.LogInformation("Can not find file entity with id {0}", id);
                return false;
            }
            return File.Exists(fileEntity.Location);
        }

        public async Task<bool> UploadAsync(IFormFile file)
        {
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            var storedPath = Path.Combine(contentRootPath, _storedFolder);
            // save to db
            var fileEntity = new FileEntity(storedPath, file.FileName);
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _fileRepository.Create(fileEntity);
                // write to location
                SetupStoredFolder(storedPath);
                using (var fileStream = new FileStream(fileEntity.Location, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex, "Upload async failed");
                await _unitOfWork.RollBackTransactionAsync();
                TryDeleteFile(fileEntity.Location);
                return false;
            }
        }

        public static void SetupStoredFolder(string storedPath)
        {
            if (Directory.Exists(storedPath) == false)
            {
                Directory.CreateDirectory(storedPath);
            }
        }

        public static void TryDeleteFile(string location)
        {
            if (File.Exists(location))
            {
                File.Delete(location);
            }
        }
    }
}
