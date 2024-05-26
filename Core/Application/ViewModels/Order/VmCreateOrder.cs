namespace Application.ViewModels.Order;

public class VmCreateOrder
{
    public string CustomerName { get; set; }

    public Guid ProductId { get; set; }
    public Guid CompanyId { get; set; }
}