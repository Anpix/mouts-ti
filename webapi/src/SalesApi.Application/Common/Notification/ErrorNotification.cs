using MediatR;

namespace SalesApi.Application.Common.Notification;

public class ErrorNotification : INotification
{
    public required string Error { get; set; }
    public string? Stack { get; set; }
}
