using CleanShop.Domain.Entities;

namespace CleanShop.Common.Business;

public interface IOrderLineReadFacade
{
    Task<IEnumerable<OrderLine>> GetAllAsync();
    Task<OrderLine?> GetByIdAsync(int id);
}
