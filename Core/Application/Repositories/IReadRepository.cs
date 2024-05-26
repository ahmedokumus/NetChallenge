using Domain.Common;

namespace Application.Repositories;

public interface IReadRepository<T> : IRepositoyBase<T> where T : BaseEntity
{
    List<T> GetAll();
    T GetById(Guid Id);
}