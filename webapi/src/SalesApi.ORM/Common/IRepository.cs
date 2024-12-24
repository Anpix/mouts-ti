using SalesApi.Domain.Common;

namespace SalesApi.ORM.Common;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll(int skip, int take);
    Task<T?> GetById(Guid id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
    int SaveChanges();
    Task<bool> ExistsById(Guid id);
}
