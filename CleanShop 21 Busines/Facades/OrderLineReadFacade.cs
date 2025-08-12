using CleanShop.Domain.Entities;
using CleanShop.Common.Data;
using CleanShop.Common.Business;

namespace CleanShop.Application.Facades;

public class OrderLineReadFacade : IOrderLineReadFacade
{
    private readonly IOrderLineRepository _orderLineRepository;

    public OrderLineReadFacade(IOrderLineRepository orderLineRepository) => _orderLineRepository = orderLineRepository;

    public Task<IEnumerable<OrderLine>> GetAllAsync()
    {
        return _orderLineRepository.GetAllAsync();
    }

    public Task<OrderLine?> GetByIdAsync(int id)
    {
        return _orderLineRepository.GetByIdAsync(id);
    }
}
