using MediatR;
using SalesApi.Application.Common.Responses;
using SalesApi.Application.UseCases.Sales.Models;

namespace SalesApi.Application.UseCases.Sales.Queries.GetById;

public class GetByIdSaleQuery : IRequest<BaseQueryResponse<SaleDto>>
{
    public GetByIdSaleQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
