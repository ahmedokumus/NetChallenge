using Application.Repositories;
using Domain.Common;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly NetChallengeDbContext _context;

    public WriteRepository(NetChallengeDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public void Add(T entity)
    {
        EntityEntry<T> entryEntry = Table.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        EntityEntry<T> entityEntry = Table.Update(entity);
        _context.SaveChanges();
    }
}