using FluentValidation;
using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
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
