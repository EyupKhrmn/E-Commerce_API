using System.Linq.Expressions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Common;
using ETicaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistance.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly ETicaretApıDbContext _context;

    public ReadRepository(ETicaretApıDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll()
        => Table;

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

    public async Task<T> GetByIdAsync(string id)
        => await Table.FindAsync(Guid.Parse(id));
}