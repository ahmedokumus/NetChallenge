using Domain.Common;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public string CustomerName { get; set; }
    public TimeSpan OrderTime { get; set; }

    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}