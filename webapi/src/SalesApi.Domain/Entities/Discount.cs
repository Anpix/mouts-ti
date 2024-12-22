using SalesApi.Domain.Common;

namespace SalesApi.Domain.Entities;

public class Discount : BaseEntity
{
    public required Sale Sale { get; set; }
    public decimal Percent { get; set; }
    public decimal Amount { get; set; }
    public Product? SaleProduct { get; set; }
}
