using MediatR;
using SalesApi.Application.Common.Responses;
using SalesApi.Application.UseCases.Sales.Models;

namespace SalesApi.Application.UseCases.Sales.Queries.GetAll;

public class GetAllSaleQuery : IRequest<BaseQueryResponse<IEnumerable<SaleDto>>>
{
    public GetAllSaleQuery(int skip = 0, int take = 0)
    {
        Skip = skip;
        Take = take;
    }

    public int Skip { get; set; }
    public int Take { get; set; }
}
