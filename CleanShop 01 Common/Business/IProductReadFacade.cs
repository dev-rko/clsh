using CleanShop.Domain.Entities;

namespace CleanShop.Common.Business;

public interface IProductReadFacade
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
}
