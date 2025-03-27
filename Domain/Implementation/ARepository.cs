using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repo;

public class ARepository<TEntity> :IRepository<TEntity> where TEntity : class
{
    
    protected readonly BuchContext _context;
    protected readonly DbSet<TEntity> _table;

    protected ARepository(BuchContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity t)
    {
        await _table.AddAsync(t);
        await _context.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list)
    {
        await _table.AddRangeAsync(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task UpdataAsync(TEntity t)
    {
        _context.ChangeTracker.Clear();
        _table.Update(t);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list)
    {
        _table.UpdateRange(list);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> ReadAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _table.Where(filter).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAsync(int start, int count)
    {
        return await _table.Skip(start).Take(count).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAllAsync()
    {
        return await _table.ToListAsync();
    }

    public async Task DeleteAsync(TEntity t)
    {
        _table.Remove(t);
        await _context.SaveChangesAsync();
    }
}
