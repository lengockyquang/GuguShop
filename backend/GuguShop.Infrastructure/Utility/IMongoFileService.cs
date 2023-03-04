using System;
using System.Threading.Tasks;

namespace GuguShop.Infrastructure.Utility
{
    public interface IMongoFileService: IFileService
    {
        Task<byte[]> Download(Guid id);
    }
}
