using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesApi.Application.Common.Responses;
using SalesApi.Application.UseCases.Sales.Models;
using SalesApi.ORM.Repositories;

namespace SalesApi.Application.UseCases.Sales.Queries.GetAll;

public class GetAllSaleHandler : IRequestHandler<GetAllSaleQuery, BaseQueryResponse<IEnumerable<SaleDto>>>
{
    private readonly ILogger<GetAllSaleHandler> _logger;
    private readonly ISaleRepository _repository;
    private readonly IMapper _mapper;

    public GetAllSaleHandler(ILogger<GetAllSaleHandler> logger,
                              ISaleRepository repository,
                              IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<BaseQueryResponse<IEnumerable<SaleDto>>> Handle(GetAllSaleQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetAll(request.Skip, request.Take);
            var sales = _mapper.Map<IEnumerable<SaleDto>>(entity);

            return new BaseQueryResponse<IEnumerable<SaleDto>>
            {
                Success = true,
                Message = "Sales retrieved successfully",
                Data = sales,
            };
        }
        catch (Exception ex)
        {
            var message = "Error getting sales";
            _logger.LogError(ex, message);
            return new BaseQueryResponse<IEnumerable<SaleDto>>
            {
                Message = message,
            };
        }
    }
}
