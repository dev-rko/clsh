using CleanShop.Domain.Entities;
using CleanShop.Common.Data;
using CleanShop.Common.Business;

namespace CleanShop.Application.Facades;

public class OrderReadFacade : IOrderReadFacade
{
    private readonly IOrderRepository _orderRepository;

    public OrderReadFacade(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        return _orderRepository.GetAllAsync();
    }

    public Task<Order?> GetByIdAsync(int id)
    {
        return _orderRepository.GetByIdAsync(id);
    }
}
