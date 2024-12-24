using FluentValidation;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleUpdate;

public class SaleUpdateCommandValidator : AbstractValidator<SaleUpdateCommand>
{
    public SaleUpdateCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(sale => sale.Number)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(sale => sale.CustomerId).NotEmpty();
        RuleFor(sale => sale.BranchId).NotEmpty();
        RuleFor(sale => sale.Date).NotEmpty();
        RuleFor(sale => sale.Value)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(x => x.IsCanceled).NotEmpty();
    }
}
