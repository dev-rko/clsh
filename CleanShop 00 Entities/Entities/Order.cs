using System.Collections.ObjectModel;

namespace CleanShop.Domain.Entities;

public sealed class Order : EntityBase
{
    public DateTime CreatedUtc { get; init; } = DateTime.UtcNow;
    public string CustomerName { get; set; } = string.Empty;

    public IList<OrderLine> Lines { get; } = new List<OrderLine>();

    public decimal Total => Lines.Sum(l => l.LineTotal);
}
