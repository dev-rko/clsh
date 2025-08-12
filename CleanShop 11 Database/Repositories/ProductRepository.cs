using CleanShop.Common.Data;
using CleanShop.Database.Data;
using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Database.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopDbContext _db;

    public ProductRepository(ShopDbContext db) => _db = db;

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _db.Products.AsNoTracking().ToListAsync().ConfigureAwait(false);

    public Task<Product?> GetByIdAsync(int id)
        => _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task UpdateAsync(Product product)
    {
        _db.Products.Update(product);
        await _db.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task RemoveAsync(int id)
    {
        Product? product = await _db.Products.FindAsync(id).ConfigureAwait(false);
        if (product != null)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
