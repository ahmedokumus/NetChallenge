using Application.Utilities.Results.Abstract;
using Application.ViewModels.Company;
using Domain.Entities;

namespace Application.Services;

public interface ICompanyService
{
    IDataResult<List<Company>> GetAll();
    IDataResult<Company> GetById(Guid id);
    IResult Add(VmCreateCompany vmCreateCompany);
    IResult Update(VmUpdateCompany vmUpdateCompany);

}