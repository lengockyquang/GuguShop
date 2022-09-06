using System;
using System.Linq;
using System.Linq.Expressions;
using GuguShop.Domain.Base.Entities;
using GuguShop.Infrastructure.Utility;

namespace GuguShop.Infrastructure.Specification;

public class Specification<TEntity> where TEntity: Entity<Guid>
{
    public Expression<Func<TEntity, bool>> Filter { get; set; }
    public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> Order { get; set; }
    public string IncludeProperties { get; set; }
    public EfTrackingType EfTrackingType { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }

    public Specification()
    {
        
    }

    public Specification(int limit, int offset)
    {
        if(limit == 0)
        {
            limit = -1;
        }
        Limit = limit;
        Offset = offset;
    }
    
    public Specification(Expression<Func<TEntity, bool>> filter,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order, string includeProperties, EfTrackingType efTrackingType)
    {
        Filter = filter;
        Order = order;
        IncludeProperties = includeProperties;
        EfTrackingType = efTrackingType;
    }
}