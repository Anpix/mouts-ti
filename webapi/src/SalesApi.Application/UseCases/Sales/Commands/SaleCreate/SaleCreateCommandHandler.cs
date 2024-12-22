using MediatR;
using SalesApi.Application.Common.Notification;
using SalesApi.Application.Common.Responses;
using SalesApi.Domain.Entities;
using SalesApi.ORM.Repositories;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleCreate;

public class SaleCreateCommandHandler : IRequestHandler<SaleCreateCommand, BaseCommandResponse<Guid>>
{
    private readonly IMediator _mediator;
    private readonly ISaleRepository _repository;

    public SaleCreateCommandHandler(IMediator mediator, ISaleRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<BaseCommandResponse<Guid>> Handle(SaleCreateCommand request, CancellationToken cancellationToken)
    {
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            Number = request.Number,
            CustomerId = request.CustomerId,
            BranchId = request.BranchId,
            Date = request.Date,
            Value = request.Value,
            IsCanceled = request.IsCanceled
        };

        try
        {
            var entity = await _repository.Add(sale);
            _repository.SaveChanges();

            await _mediator.Publish(new SaleCreateNotification
            {
                Id = entity.Id,
                Number = entity.Number,
                CustomerId = entity.CustomerId,
                Value = entity.Value
            });

            var response = new BaseCommandResponse<Guid>()
            {
                Success = true,
                Message = $"Sale created",
                Data = entity.Id
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new SaleCreateNotification { Id = sale.Id, Number = sale.Number, Value = sale.Value });
            await _mediator.Publish(new ErrorNotification { Error = ex.Message, Stack = ex.StackTrace });
            
            var response = new BaseCommandResponse<Guid>()
            {
                Success = false,
                Message = $"Error creating the Sale"
            };

            return await Task.FromResult(response);
        }
    }

}
