using CleanShop.Domain.Entities;
using CleanShop.Common.Data;
using CleanShop.Common.Business;

namespace CleanShop.Application.Facades;

public class ProductReadFacade : IProductReadFacade
{
    private readonly IProductRepository _productRepository;

    public ProductReadFacade(IProductRepository productRepository) => _productRepository = productRepository;

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return _productRepository.GetAllAsync();
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        return _productRepository.GetByIdAsync(id);
    }
}
