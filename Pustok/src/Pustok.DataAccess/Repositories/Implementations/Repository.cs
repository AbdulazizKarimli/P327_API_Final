using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Pustok.DataAccess.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll(params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }

    public IQueryable<T> GetFiltered(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query.Where(expression);
    }

    public async Task<T> GetByIdAsync(Guid id, params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(expression);
    }

    public async Task CreateAsync(T entity)
        => await _context.Set<T>().AddAsync(entity);

    public void Update(T entity)
        => _context.Set<T>().Update(entity);

    public void Delete(T entity)
        => _context.Set<T>().Remove(entity);

    public void SoftDelete(T entity)
    {
        entity.IsDeleted = true;
        Update(entity);
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        => await _context.Set<T>().AnyAsync(expression);

    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
}