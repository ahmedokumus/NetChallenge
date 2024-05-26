using Domain.Common;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }

    public ICollection<Order> Orders { get; set; }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}