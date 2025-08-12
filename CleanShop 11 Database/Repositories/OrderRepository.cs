using CleanShop.Common.Data;
using CleanShop.Database.Data;
using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Database.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ShopDbContext _db;

    public OrderRepository(ShopDbContext db) => _db = db;

    public async Task<IEnumerable<Order>> GetAllAsync()
        => await _db.Orders.AsNoTracking().Include(o => o.Lines).ToListAsync().ConfigureAwait(false);

    public Task<Order?> GetByIdAsync(int id)
        => _db.Orders.AsNoTracking().Include(o => o.Lines).FirstOrDefaultAsync(o => o.Id == id);

    public async Task AddAsync(Order order)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task UpdateAsync(Order order)
    {
        _db.Orders.Update(order);
        await _db.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task RemoveAsync(int id)
    {
        Order? order = await _db.Orders.FindAsync(id).ConfigureAwait(false);
        if (order != null)
        {
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
