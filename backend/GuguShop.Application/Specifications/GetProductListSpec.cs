using System;
using System.Linq;
using System.Linq.Expressions;
using GuguShop.Domain.Entities;
using GuguShop.Infrastructure.Specification;
using GuguShop.Infrastructure.Utility;

namespace GuguShop.Application.Specifications;

public class GetProductListSpec : Specification<Product>
{
    public GetProductListSpec()
    {
        Filter = null;
        Order = queryable => queryable.OrderBy(x => x.Name);
        IncludeProperties = "Category, Manufacturer";
    }

    public GetProductListSpec(int limit, int offset) : base(limit, offset)
    {
    }

    public GetProductListSpec(Expression<Func<Product, bool>> filter,
        Func<IQueryable<Product>, IOrderedQueryable<Product>> order,
        string includeProperties) : base(filter,
        order,
        includeProperties,
        EfTrackingType.DefaultTracking
    )
    {
    }
}