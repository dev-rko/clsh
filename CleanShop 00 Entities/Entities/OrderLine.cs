namespace CleanShop.Domain.Entities;

public sealed class OrderLine : EntityBase
{
    public Order Order { get; set; } = null!; // Required for EF Core
    public Product Product { get; set; } = null!; // Required for EF Core

    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal => Quantity * UnitPrice;
}
