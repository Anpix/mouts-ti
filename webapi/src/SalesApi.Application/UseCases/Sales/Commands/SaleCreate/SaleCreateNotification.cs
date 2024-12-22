using MediatR;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleCreate;

public class SaleCreateNotification : INotification
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Value { get; set; }
}
