using FluentValidation;
using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Validation;

public class DiscountValidator : AbstractValidator<Discount>
{
    public DiscountValidator()
    {
        RuleFor(saleProduct => saleProduct.Sale).SetValidator(new SaleValidator());
        
        RuleFor(saleProduct => saleProduct.Amount)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(saleProduct => saleProduct.Percent)
            .NotEmpty()
            .GreaterThan(0);
    }
}
