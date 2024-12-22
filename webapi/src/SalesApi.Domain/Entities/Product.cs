using SalesApi.Domain.Common;

namespace SalesApi.Domain.Entities;

public class Product : BaseEntity
{
    public required Sale Sale { get; set; }
    public required Guid ProductId { get; set; }
    public int Quantity { get; set; }

}
