using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public interface IRepositoyBase<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}