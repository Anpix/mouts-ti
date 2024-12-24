using FluentValidation;
using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(saleProduct => saleProduct.Sale).SetValidator(new SaleValidator());
        
        RuleFor(saleProduct => saleProduct.ProductId).NotEmpty();

        RuleFor(saleProduct => saleProduct.Quantity)
            .NotEmpty()
            .GreaterThan(0);
    }
}
