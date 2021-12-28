using System;

namespace GuguShop.Domain.Base.Entities
{
    public class Entity<TKey>
    {
        public  TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}