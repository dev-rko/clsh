using CleanShop.Domain.Entities;
using FluentValidation;

namespace CleanShop.Application.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.CustomerName).NotEmpty();
        RuleFor(o => o.Lines).NotEmpty().WithMessage("Order must have at least one line.");
    }
}
