using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Events;

public class SaleCreatedEvent
{
    public Sale Sale { get; set; }

    public SaleCreatedEvent(Sale sale)
    {
        Sale = sale;
    }
}
