using CleanShop.Domain.Entities;

namespace CleanShop.Common.Business;

public interface IOrderWriteFacade
{
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task RemoveAsync(int id);
}
