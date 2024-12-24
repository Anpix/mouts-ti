using MediatR;
using SalesApi.Application.Common.Responses;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleDelete;

public class SaleDeleteCommand : IRequest<BaseCommandResponse<Guid>>
{
    public Guid Id { get; set; }
}
