using Application.Repositories.CompanyRepo;
using Application.Services;
using Application.Utilities.Messages;
using Application.Utilities.Results.Abstract;
using Application.Utilities.Results.Concrete;
using Application.ViewModels.Company;
using Domain.Entities;

namespace Persistence.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyReadRepo _companyReadRepo;
    private readonly ICompanyWriteRepo _companyWriteRepo;

    public CompanyService(ICompanyReadRepo companyReadRepo, ICompanyWriteRepo companyWriteRepo)
    {
        _companyReadRepo = companyReadRepo;
        _companyWriteRepo = companyWriteRepo;
    }

    public IDataResult<List<Company>> GetAll()
    {
        if (DateTime.Now.Hour == 01)
        {
            return new ErrorDataResult<List<Company>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<Company>>(_companyReadRepo.GetAll(), Messages.CompaniesListed);
    }

    public IDataResult<Company> GetById(Guid id)
    {
        return new SuccessDataResult<Company>(_companyReadRepo.GetById(id));
    }

    public IResult Add(VmCreateCompany vmCreateCompany)
    {
        Company company = new()
        {
            Name = vmCreateCompany.Name,
            Status = vmCreateCompany.Status,
            OrderPermitStartTime = vmCreateCompany.OrderPermitStartTime,
            OrderPermitFinishTime = vmCreateCompany.OrderPermitFinishTime
        };
        _companyWriteRepo.Add(company);
        return new SuccessResult(Messages.CompanyAdded);
    }

    public IResult Update(VmUpdateCompany vmUpdateCompany)
    {
        Company company = _companyReadRepo.GetById(vmUpdateCompany.Id);
        company.Status = vmUpdateCompany.Status;
        company.OrderPermitStartTime = vmUpdateCompany.OrderPermitStartTime;
        company.OrderPermitFinishTime = vmUpdateCompany.OrderPermitFinishTime;

        _companyWriteRepo.Update(company);
        return new SuccessResult(Messages.CompanyUpdated);
    }
}