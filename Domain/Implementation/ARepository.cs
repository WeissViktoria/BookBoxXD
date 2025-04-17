using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repo;

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly IDbContextFactory<BuchContext> _contextFactory;

    protected ARepository(IDbContextFactory<BuchContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<TEntity> CreateAsync(TEntity t)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<TEntity>().Add(t);
        await context.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<TEntity>().AddRange(list);
        await context.SaveChangesAsync();
        return list;
    }

    public async Task UpdateAsync(TEntity t)
    {
        using var context = _contextFactory.CreateDbContext();
        context.ChangeTracker.Clear();
        context.Set<TEntity>().Update(t);
        await context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<TEntity>().UpdateRange(list);
        await context.SaveChangesAsync();
    }

    public async Task<TEntity?> ReadAsync(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Set<TEntity>().Where(filter).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAsync(int start, int count)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Set<TEntity>().Skip(start).Take(count).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAllAsync()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task DeleteAsync(TEntity t)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<TEntity>().Remove(t);
        await context.SaveChangesAsync();
    }
    
}
