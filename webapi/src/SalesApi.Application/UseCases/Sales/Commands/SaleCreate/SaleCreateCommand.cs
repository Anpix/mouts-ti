using MediatR;
using SalesApi.Application.Common.Responses;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleCreate;

public class SaleCreateCommand : IRequest<BaseCommandResponse<Guid>>
{
    public int Number { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public bool IsCanceled { get; set; }
}
