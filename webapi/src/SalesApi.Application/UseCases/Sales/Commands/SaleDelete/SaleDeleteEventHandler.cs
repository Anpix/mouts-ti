using MediatR;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleDelete;

public class SaleDeleteEventHandler : INotificationHandler<SaleDeleteNotification>
{
    public Task Handle(SaleDeleteNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Sale deleted: {notification.Id}");
        });
    }
}
