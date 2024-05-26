using Application.Utilities.Results.Abstract;
using Application.ViewModels.Company;
using Application.ViewModels.Product;
using Domain.Entities;

namespace Application.Services;

public interface IProductService
{
    IDataResult<List<Product>> GetAll();
    IResult Add(VmCreateProduct vmCreateProduct);

}