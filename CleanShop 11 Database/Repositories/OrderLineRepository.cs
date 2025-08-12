using CleanShop.Common.Data;
using CleanShop.Database.Data;
using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Database.Repositories;

public class OrderLineRepository : IOrderLineRepository
{
    private readonly ShopDbContext _db;

    public OrderLineRepository(ShopDbContext db) => _db = db;

    public async Task<IEnumerable<OrderLine>> GetAllAsync()
        => await _db.OrderLines.AsNoTracking().ToListAsync().ConfigureAwait(false);

    public Task<OrderLine?> GetByIdAsync(int id)
        => _db.OrderLines.AsNoTracking().FirstOrDefaultAsync(ol => ol.Id == id);

    public async Task AddAsync(OrderLine orderLine)
    {
        _db.OrderLines.Add(orderLine);
        await _db.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task UpdateAsync(OrderLine orderLine)
    {
        _db.OrderLines.Update(orderLine);
        await _db.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task RemoveAsync(int id)
    {
        OrderLine? orderLine = await _db.OrderLines.FindAsync(id).ConfigureAwait(false);
        if (orderLine != null)
        {
            _db.OrderLines.Remove(orderLine);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
