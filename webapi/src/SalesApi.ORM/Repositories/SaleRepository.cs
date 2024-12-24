using SalesApi.Domain.Entities;
using SalesApi.ORM.Common;
using SalesApi.ORM.Contexts;

namespace SalesApi.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : Repository<Sale>, ISaleRepository
{
    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(SalesDbContext context) : base(context)
    {
    }
}
