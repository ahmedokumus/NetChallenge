using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class NetChallengeDbContext : DbContext
{
    public NetChallengeDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}