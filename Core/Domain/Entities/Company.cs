using Domain.Common;

namespace Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public TimeSpan OrderPermitStartTime { get; set; }
    public TimeSpan OrderPermitFinishTime { get; set; }

    public ICollection<Product>? Products { get; set; }
}