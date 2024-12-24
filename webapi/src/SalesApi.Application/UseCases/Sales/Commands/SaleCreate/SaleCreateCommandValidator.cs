using FluentValidation;

namespace SalesApi.Application.UseCases.Sales.Commands.SaleCreate;

public class SaleCreateCommandValidator : AbstractValidator<SaleCreateCommand>
{
    public SaleCreateCommandValidator()
    {
        RuleFor(sale => sale.Number)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(sale => sale.CustomerId).NotEmpty();
        RuleFor(sale => sale.BranchId).NotEmpty();
        RuleFor(sale => sale.Date).NotEmpty();
        RuleFor(sale => sale.Value)
            .NotEmpty()
            .GreaterThan(0);
    }
}
