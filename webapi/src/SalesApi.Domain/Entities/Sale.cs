using SalesApi.Domain.Common;

namespace SalesApi.Domain.Entities;

public class Sale : BaseEntity
{
    public int Number { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public bool IsCanceled { get; set; }
}
