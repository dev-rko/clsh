using CleanShop.Domain.Entities;

namespace CleanShop.Common.Business;

public interface IOrderLineWriteFacade
{
    Task AddAsync(OrderLine orderLine);
    Task UpdateAsync(OrderLine orderLine);
    Task RemoveAsync(int id);
}
