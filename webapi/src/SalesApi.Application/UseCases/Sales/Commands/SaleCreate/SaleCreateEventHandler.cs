using MediatR;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleCreate;

public class SaleCreateEventHandler : INotificationHandler<SaleCreateNotification>
{
    public Task Handle(SaleCreateNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Sale created: {notification.Id} - {notification.Number} - {notification.Value}");
        });
    }
}
