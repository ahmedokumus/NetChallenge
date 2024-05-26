namespace Application.ViewModels.Product;

public class VmCreateProduct
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }

    public Guid CompanyId { get; set; }
}