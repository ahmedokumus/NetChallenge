using Application.Repositories.ProductRepo;
using Persistence.Contexts;

namespace Persistence.Repositories.Product;

public class ProductWriteRepo : WriteRepository<Domain.Entities.Product>, IProductWriteRepo
{
    public ProductWriteRepo(NetChallengeDbContext context) : base(context)
    {
    }
}