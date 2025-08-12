using CleanShop.Domain.Entities;
using FluentValidation;

namespace CleanShop.Application.Validators;

public class OrderLineValidator : AbstractValidator<OrderLine>
{
    public OrderLineValidator()
    {
        RuleFor(ol => ol.Quantity).GreaterThan(0);
        RuleFor(ol => ol.UnitPrice).GreaterThanOrEqualTo(0);
        RuleFor(ol => ol.ProductId).GreaterThan(0);
    }
}
