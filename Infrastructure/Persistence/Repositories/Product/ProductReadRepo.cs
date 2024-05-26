using Application.Repositories.ProductRepo;
using Persistence.Contexts;

namespace Persistence.Repositories.Product;

public class ProductReadRepo : ReadRepository<Domain.Entities.Product>, IProductReadRepo
{
    public ProductReadRepo(NetChallengeDbContext context) : base(context)
    {
    }
}