namespace SalesApi.Application.UseCases.Sales.Models;

public class SaleDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public bool IsCanceled { get; set; }
}
