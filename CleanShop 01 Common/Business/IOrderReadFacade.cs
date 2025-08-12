using CleanShop.Domain.Entities;

namespace CleanShop.Common.Business;

public interface IOrderReadFacade
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
}
