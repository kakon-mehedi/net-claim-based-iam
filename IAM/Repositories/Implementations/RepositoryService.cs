using System;
using System.Linq.Expressions;
using IAM.Database;
using Microsoft.EntityFrameworkCore;

namespace IAM.Repositories.Implementations;

public class RepositoryService<T> : IRepositoryService<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _entities;

    public RepositoryService(ApplicationDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public DbSet<T> GetEntities() 
    {
        return _entities;
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<T?> GetItemByFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _entities.FirstOrDefaultAsync(filter);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }
}
