using CleanShop.Domain.Entities;
using CleanShop.Application.Validators;
using CleanShop.Common.Data;
using CleanShop.Common.Business;
using FluentValidation;

namespace CleanShop.Application.Facades;

public class OrderLineWriteFacade : IOrderLineWriteFacade
{
    private readonly IOrderLineRepository _orderLineRepository;
    private readonly OrderLineValidator _validator = new();

    public OrderLineWriteFacade(IOrderLineRepository orderLineRepository) =>
        _orderLineRepository = orderLineRepository;

    public async Task AddAsync(OrderLine orderLine)
    {
        FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(orderLine).ConfigureAwait(false);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        await _orderLineRepository.AddAsync(orderLine).ConfigureAwait(false);
    }

    public async Task UpdateAsync(OrderLine orderLine)
    {
        FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(orderLine).ConfigureAwait(false);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        await _orderLineRepository.UpdateAsync(orderLine).ConfigureAwait(false);
    }

    public async Task RemoveAsync(int id)
    {
        await _orderLineRepository.RemoveAsync(id).ConfigureAwait(false);
    }
}
