using CleanShop.Domain.Entities;

namespace CleanShop.Common.Business;

public interface IProductWriteFacade
{
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task RemoveAsync(int id);
}
