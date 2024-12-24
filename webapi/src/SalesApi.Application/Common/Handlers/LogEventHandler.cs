using MediatR;
using SalesApi.Application.Common.Notification;

namespace SalesApi.Application.Common.Handlers;

public class LogEventHandler :
    INotificationHandler<ErrorNotification>
{
    public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Error: {notification.Error}");
            Console.WriteLine($"Stack: {notification.Stack}");
        });
    }
}
