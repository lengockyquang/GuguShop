using System.Linq;
using GuguShop.Domain.Entities;
using GuguShop.Infrastructure.Specification;

namespace GuguShop.Application.Specifications;

public class GetProductListSpec : Specification<Product>
{
    public GetProductListSpec(int limit, int offset)
    {
        Filter = null;
        Order = queryable => queryable.OrderBy(x => x.Name);
        IncludeProperties = "Category, Manufacturer";
        Limit = limit == 0 ? -1 : limit;
        Offset = offset;
    }
}