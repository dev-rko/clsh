using CleanShop.Domain.Entities;

namespace CleanShop.Common.Data;

public interface IOrderLineRepository
{
    Task<IEnumerable<OrderLine>> GetAllAsync();
    Task<OrderLine?> GetByIdAsync(int id);
    Task AddAsync(OrderLine orderLine);
    Task UpdateAsync(OrderLine orderLine);
    Task RemoveAsync(int id);
}
