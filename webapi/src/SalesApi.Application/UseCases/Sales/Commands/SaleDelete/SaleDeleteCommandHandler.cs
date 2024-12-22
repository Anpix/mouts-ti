using MediatR;
using SalesApi.Application.Common.Notification;
using SalesApi.Application.Common.Responses;
using SalesApi.ORM.Repositories;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleDelete;

public class SaleDeleteCommandHandler : IRequestHandler<SaleDeleteCommand, BaseCommandResponse<Guid>>
{
    private readonly IMediator _mediator;
    private readonly ISaleRepository _repository;

    public SaleDeleteCommandHandler(IMediator mediator, ISaleRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<BaseCommandResponse<Guid>> Handle(SaleDeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.Delete(request.Id);
            _repository.SaveChanges();

            await _mediator.Publish(new SaleDeleteNotification
            {
                Id = request.Id
            });

            var response = new BaseCommandResponse<Guid>()
            {
                Success = true,
                Message = $"Sale deleted",
                Data = request.Id
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new SaleDeleteNotification { Id = request.Id });
            await _mediator.Publish(new ErrorNotification { Error = ex.Message, Stack = ex.StackTrace });

            var response = new BaseCommandResponse<Guid>()
            {
                Success = false,
                Message = $"Error deleting the Sale",
                Data = request.Id
            };

            return await Task.FromResult(response);
        }
    }

}
