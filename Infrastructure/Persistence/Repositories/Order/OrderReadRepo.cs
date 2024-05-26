using Application.Repositories.OrderRepo;
using Persistence.Contexts;

namespace Persistence.Repositories.Order;

public class OrderReadRepo : ReadRepository<Domain.Entities.Order>, IOrderReadRepo
{
    public OrderReadRepo(NetChallengeDbContext context) : base(context)
    {
    }
}