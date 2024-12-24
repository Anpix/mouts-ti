using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.UseCases.Sales.Commands.SaleCreate;
using SalesApi.Application.UseCases.Sales.Commands.SaleDelete;
using SalesApi.Application.UseCases.Sales.Commands.SaleUpdate;
using SalesApi.Application.UseCases.Sales.Models;
using SalesApi.Application.UseCases.Sales.Queries.ExistsById;
using SalesApi.Application.UseCases.Sales.Queries.GetAll;
using SalesApi.Application.UseCases.Sales.Queries.GetById;
using SalesApi.ORM.Repositories;
using SalesApi.WebApi.Common;
using SalesApi.WebApi.Common.Responses;

namespace SalesApi.WebApi.Features.Sales;

/// <summary>
/// Controller for managing sale operations
/// </summary>
public class SalesController : BaseController
{
    private readonly ILogger<SalesController> _logger;
    private readonly IMediator _mediator;
    private readonly ISaleRepository _repository;

    /// <summary>
    /// Initializes a new instance of SalesController
    /// </summary>
    /// <param name="logger">The logger instance</param>
    /// <param name="repository">The SaleRepository instance</param>
    /// <param name="mediator">The mediator instance</param>
    public SalesController(ILogger<SalesController> logger,
                           ISaleRepository repository,
                           IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetMany(int skip = 0, int take = 10)
    {
        var result = await _mediator.Send(new GetAllSaleQuery(skip, take));

        return CustomResponse(new ApiResponseWithData<IEnumerable<SaleDto>>()
        {
            Success = result.Success,
            Message = result.Message,
            Data = result.Data
        });
    }

    [HttpGet("{id:Guid}", Name = "GetById")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetByIdSaleQuery(id));
        if (result.Data == null)
            return NotFound();

        return CustomResponse(new ApiResponseWithData<SaleDto>()
        {
            Success = result.Success,
            Message = result.Message,
            Data = result.Data
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SaleCreateCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new ApiResponseWithData<Guid>()
        {
            Success = result.Success,
            Message = result.Message,
            Data = result.Data
        };
            
        if (!result.Success)
            return CustomResponse(response);

        return Created(nameof(GetById), new { Id = result.Data }, response);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] SaleUpdateCommand command)
    {
        if (command.Id != id)
            return BadRequest("The Id from in the request body does not match the Id from the route");

        var exists = await _mediator.Send(new ExistsByIdSaleQuery(id));
        if (!exists.Data)
            return NotFound();

        var result = await _mediator.Send(command);

        return CustomResponse(new ApiResponseWithData<Guid>()
        {
            Success = result.Success,
            Message = result.Message,
            Data = result.Data
        });
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var exists = await _mediator.Send(new ExistsByIdSaleQuery(id));
        if(!exists.Data)
            return NotFound();

        var result = await _mediator.Send(new SaleDeleteCommand { Id = id });

        return CustomResponse(new ApiResponseWithData<Guid>()
        {
            Success = result.Success,
            Message = result.Message,
            Data = result.Data
        });
    }
}
