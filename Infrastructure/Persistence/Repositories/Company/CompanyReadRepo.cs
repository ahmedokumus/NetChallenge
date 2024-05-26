using Application.Repositories.CompanyRepo;
using Persistence.Contexts;

namespace Persistence.Repositories.Company;

public class CompanyReadRepo : ReadRepository<Domain.Entities.Company>, ICompanyReadRepo
{
    public CompanyReadRepo(NetChallengeDbContext context) : base(context)
    {
    }
}