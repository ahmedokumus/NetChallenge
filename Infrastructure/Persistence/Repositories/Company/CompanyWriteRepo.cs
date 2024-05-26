using Application.Repositories.CompanyRepo;
using Persistence.Contexts;

namespace Persistence.Repositories.Company;

public class CompanyWriteRepo : WriteRepository<Domain.Entities.Company>, ICompanyWriteRepo
{
    public CompanyWriteRepo(NetChallengeDbContext context) : base(context)
    {
    }
}