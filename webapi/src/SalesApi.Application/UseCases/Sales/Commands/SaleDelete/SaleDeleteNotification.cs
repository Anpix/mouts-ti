using MediatR;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleDelete;

public class SaleDeleteNotification : INotification
{
    public Guid Id { get; set; }
}
