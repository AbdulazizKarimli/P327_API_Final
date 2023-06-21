using Pustok.Core.Entities.Common;
using System.Linq.Expressions;

namespace Pustok.DataAccess.Repositories.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(params string[] includes);
    IQueryable<T> GetFiltered(Expression<Func<T, bool>> expression, params string[] includes);
    Task<T> GetByIdAsync(Guid id, params string[] includes);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params string[] includes);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    void SoftDelete(T entity);
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);

    Task<int> SaveAsync();
}