using GuguShop.Domain.Base.Entities;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace GuguShop.Domain.Entities
{
    public  class FileEntity: Entity<Guid>
    {
        public FileEntity()
        {

        }
        public FileEntity(string storedPath, string fileName)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
            Location = Path.Combine(storedPath, SafeFileName);
        }
        public string FileName { get; set; }
        public string Extensions { get; set; }
        public int Size { get; set; }
        public string SafeFileName => this.Id.ToString();
        public string Location { get; set; }
    }
}
