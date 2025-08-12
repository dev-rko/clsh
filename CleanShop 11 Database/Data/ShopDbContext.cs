using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Database.Data;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderLine> OrderLines => Set<OrderLine>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Sku).IsRequired().HasMaxLength(64);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(256);
            entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.Property(o => o.CustomerName).IsRequired().HasMaxLength(256);
            entity.Property(o => o.CreatedUtc).IsRequired();
            entity.HasMany(o => o.Lines)
                  .WithOne(ol => ol.Order)
                  .HasForeignKey(ol => ol.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(ol => ol.Id);
            entity.Property(ol => ol.UnitPrice).HasColumnType("decimal(18,2)");
            entity.Property(ol => ol.Quantity).IsRequired();
            entity.HasOne(ol => ol.Product)
                  .WithMany()
                  .HasForeignKey(ol => ol.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
