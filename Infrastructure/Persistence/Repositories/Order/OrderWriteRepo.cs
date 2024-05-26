using Application.Repositories.OrderRepo;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Contexts;

namespace Persistence.Repositories.Order;

public class OrderWriteRepo : WriteRepository<Domain.Entities.Order>, IOrderWriteRepo
{
    private readonly NetChallengeDbContext _context;

    public OrderWriteRepo(NetChallengeDbContext context) : base(context)
    {
        _context = context;
    }
}