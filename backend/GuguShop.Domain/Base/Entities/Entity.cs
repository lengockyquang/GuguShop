using System;

namespace GuguShop.Domain.Base.Entities
{
    public class Entity<TKey>
    {
        public  TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}