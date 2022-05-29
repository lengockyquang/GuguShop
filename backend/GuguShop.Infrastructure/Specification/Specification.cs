using System;
using System.Linq;
using System.Linq.Expressions;
using GuguShop.Domain.Base.Entities;

namespace GuguShop.Infrastructure.Specification;

public class Specification<TEntity> where TEntity: Entity<Guid>
{
    public readonly Expression<Func<TEntity, bool>> Filter;
    public readonly Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> Order;
    public readonly string IncludeProperties;
    public readonly bool AsNoTracking = false;
    public readonly bool AsNoTrackingWithIdentityResolution = false;
    public int Limit { get; set; } = -1;
    public int Offset { get; set; } = 0;


    public Specification(int limit, int offset)
    {
        Limit = limit;
        Offset = offset;
    }
    
    public Specification(Expression<Func<TEntity, bool>> filter,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order, string includeProperties, bool asNoTracking = false,
        bool asNoTrackingWithIdentityResolution = false)
    {
        Filter = filter;
        Order = order;
        IncludeProperties = includeProperties;
        AsNoTracking = asNoTracking;
        AsNoTrackingWithIdentityResolution = asNoTrackingWithIdentityResolution;
    }
}