using Application.Repositories.CompanyRepo;
using Application.Repositories.ProductRepo;
using Application.Services;
using Application.Utilities.Messages;
using Application.Utilities.Results.Abstract;
using Application.Utilities.Results.Concrete;
using Application.ViewModels.Product;
using Domain.Entities;
using Persistence.Repositories.Company;

namespace Persistence.Services;

public class ProductService : IProductService
{
    private readonly IProductReadRepo _productReadRepo;
    private readonly IProductWriteRepo _productWriteRepo;

    public ProductService(IProductReadRepo productReadRepo, IProductWriteRepo productWriteRepo)
    {
        _productReadRepo = productReadRepo;
        _productWriteRepo = productWriteRepo;
    }

    public IDataResult<List<Product>> GetAll()
    {
        if (DateTime.Now.Hour == 00)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<Product>>(_productReadRepo.GetAll(), Messages.ProductsListed);
    }

    public IResult Add(VmCreateProduct vmCreateProduct)
    {
        Product product = new()
        {
            Name = vmCreateProduct.Name,
            Stock = vmCreateProduct.Stock,
            Price = vmCreateProduct.Price,
            CompanyId = vmCreateProduct.CompanyId,
        };

        _productWriteRepo.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }
}