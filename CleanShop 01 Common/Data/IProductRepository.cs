using CleanShop.Domain.Entities;

namespace CleanShop.Common.Data;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task RemoveAsync(int id);
}
