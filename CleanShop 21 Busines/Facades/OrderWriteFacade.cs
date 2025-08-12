using CleanShop.Domain.Entities;
using CleanShop.Application.Validators;
using CleanShop.Common.Data;
using CleanShop.Common.Business;
using FluentValidation;

namespace CleanShop.Application.Facades;

public class OrderWriteFacade : IOrderWriteFacade
{
    private readonly IOrderRepository _orderRepository;
    private readonly OrderValidator _validator = new();

    public OrderWriteFacade(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public async Task AddAsync(Order order)
    {
        FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(order).ConfigureAwait(false);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        await _orderRepository.AddAsync(order).ConfigureAwait(false);
    }

    public async Task UpdateAsync(Order order)
    {
        FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(order).ConfigureAwait(false);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        await _orderRepository.UpdateAsync(order).ConfigureAwait(false);
    }

    public async Task RemoveAsync(int id)
    {
        await _orderRepository.RemoveAsync(id).ConfigureAwait(false);
    }
}
