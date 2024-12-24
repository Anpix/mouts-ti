using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesApi.Application.Common.Responses;
using SalesApi.Application.UseCases.Sales.Models;
using SalesApi.ORM.Repositories;

namespace SalesApi.Application.UseCases.Sales.Queries.GetById;

public class GetByIdSaleHandler : IRequestHandler<GetByIdSaleQuery, BaseQueryResponse<SaleDto>>
{
    private readonly ILogger<GetByIdSaleHandler> _logger;
    private readonly ISaleRepository _repository;
    private readonly IMapper _mapper;

    public GetByIdSaleHandler(ILogger<GetByIdSaleHandler> logger,
                              ISaleRepository repository,
                              IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<BaseQueryResponse<SaleDto>> Handle(GetByIdSaleQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetById(request.Id);
            var sale = _mapper.Map<SaleDto>(entity);

            return new BaseQueryResponse<SaleDto>
            {
                Success = true,
                Message = "Sale retrieved successfully",
                Data = sale,
            };
        }
        catch (Exception ex)
        {
            var message = "Error getting sale by id";
            _logger.LogError(ex, message);
            return new BaseQueryResponse<SaleDto>
            {
                Message = message,
            };
        }
    }
}
