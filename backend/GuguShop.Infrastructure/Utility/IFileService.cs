using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GuguShop.Infrastructure.Utility
{
    public interface IFileService
    {
        Task<bool> IsExistAsync(Guid id);
        Task<Guid> UploadAsync(IFormFile file, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
        Task<Tuple<string, string>> GetFileLocation(Guid id);
    }
}
