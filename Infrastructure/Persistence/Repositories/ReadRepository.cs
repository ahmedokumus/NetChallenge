using Application.Repositories;
using Domain.Common;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly NetChallengeDbContext _context;

    public ReadRepository(NetChallengeDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public List<T> GetAll()
    {
        var query = Table.ToList();
        return query;
    }

    public T GetById(Guid Id)
    {
        var query = Table.AsQueryable();
        return query.FirstOrDefault(data => data.Id == Id)!;
    }
}