using MediatR;
using SalesApi.Application.Common.Notification;
using SalesApi.Application.Common.Responses;
using SalesApi.Domain.Entities;
using SalesApi.ORM.Repositories;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleUpdate;

public class SaleUpdateCommandHandler : IRequestHandler<SaleUpdateCommand, BaseCommandResponse<Guid>>
{
    private readonly IMediator _mediator;
    private readonly ISaleRepository _repository;

    public SaleUpdateCommandHandler(IMediator mediator, ISaleRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<BaseCommandResponse<Guid>> Handle(SaleUpdateCommand request, CancellationToken cancellationToken)
    {
        var sale = new Sale
        {
            Id = request.Id,
            Number = request.Number,
            CustomerId = request.CustomerId,
            BranchId = request.BranchId,
            Date = request.Date,
            Value = request.Value,
            IsCanceled = request.IsCanceled
        };

        try
        {
            await _repository.Update(sale);
            _repository.SaveChanges();

            await _mediator.Publish(new SaleUpdateNotification
            {
                Id = sale.Id,
                Number = sale.Number,
                Value = sale.Value
            });

            var response = new BaseCommandResponse<Guid>()
            {
                Success = true,
                Message = $"Sale updated",
                Data = request.Id
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new SaleUpdateNotification { Id = sale.Id, Number = sale.Number, Value = sale.Value });
            await _mediator.Publish(new ErrorNotification { Error = ex.Message, Stack = ex.StackTrace });
            
            var response = new BaseCommandResponse<Guid>()
            {
                Success = false,
                Message = $"Error updating the Sale",
                Data = request.Id
            };

            return await Task.FromResult(response);
        }
    }

}
