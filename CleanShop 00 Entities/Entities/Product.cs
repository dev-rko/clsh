namespace CleanShop.Domain.Entities;

public sealed class Product : EntityBase
{
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
