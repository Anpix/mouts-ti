using MediatR;
using SalesApi.Application.Common.Responses;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleUpdate;

public class SaleUpdateCommand : IRequest<BaseCommandResponse<Guid>>
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public bool IsCanceled { get; set; }
}
