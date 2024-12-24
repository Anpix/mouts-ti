using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesApi.Application.Common.Responses;
using SalesApi.ORM.Repositories;

namespace SalesApi.Application.UseCases.Sales.Queries.ExistsById;

public class ExistsByIdSaleHandler : IRequestHandler<ExistsByIdSaleQuery, BaseQueryResponse<bool>>
{
    private readonly ILogger<ExistsByIdSaleHandler> _logger;
    private readonly ISaleRepository _repository;
    private readonly IMapper _mapper;

    public ExistsByIdSaleHandler(ILogger<ExistsByIdSaleHandler> logger,
                                 ISaleRepository repository,
                                 IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<BaseQueryResponse<bool>> Handle(ExistsByIdSaleQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.ExistsById(request.Id);

            return new BaseQueryResponse<bool>
            {
                Success = true,
                Message = "Exists by Id executed",
                Data = result,
            };
        }
        catch (Exception ex)
        {
            var message = "Error checking if exists by Id";
            _logger.LogError(ex, message);
            return new BaseQueryResponse<bool>
            {
                Message = message,
            };
        }
    }
}
