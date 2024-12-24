using MediatR;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleUpdate;

public class SaleUpdateEventHandler : INotificationHandler<SaleUpdateNotification>
{
    public Task Handle(SaleUpdateNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Sale updated: {notification.Id} - {notification.Number} - {notification.Value}");
        });
    }
}
