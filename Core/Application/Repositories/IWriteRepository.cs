using Domain.Common;

namespace Application.Repositories;

public interface IWriteRepository<T> : IRepositoyBase<T> where T : BaseEntity
{
    void Add(T entity);
    void Update(T entity);
}