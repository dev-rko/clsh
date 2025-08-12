using CleanShop.Domain.Entities;

namespace CleanShop.Common.Data;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task RemoveAsync(int id);
}
