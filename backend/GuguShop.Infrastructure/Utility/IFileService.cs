using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace GuguShop.Infrastructure.Utility
{
    public interface IFileService
    {
        Task<bool> IsExistAsync(Guid id);
        Task<bool> UploadAsync(IFormFile file);
        Task<bool> DeleteAsync(Guid id);
        Task<Tuple<string, string>> GetFileLocation(Guid id);
    }
}
