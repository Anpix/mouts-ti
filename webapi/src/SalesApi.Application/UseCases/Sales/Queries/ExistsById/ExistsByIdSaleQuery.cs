using MediatR;
using SalesApi.Application.Common.Responses;

namespace SalesApi.Application.UseCases.Sales.Queries.ExistsById;

public class ExistsByIdSaleQuery : IRequest<BaseQueryResponse<bool>>
{
    public ExistsByIdSaleQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
