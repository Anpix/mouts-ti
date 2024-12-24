using MediatR;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleUpdate;

public class SaleUpdateNotification : INotification
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Value { get; set; }
}
