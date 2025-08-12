using CleanShop.Domain.Entities;
using FluentValidation;

namespace CleanShop.Application.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Sku).NotEmpty();
        RuleFor(p => p.Price).GreaterThanOrEqualTo(0);
    }
}
