using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace IAM.Repositories;

public interface IRepositoryService<T> where T : class
{
    DbSet<T> GetEntities();
    Task<T> GetByIdAsync(string id);
    Task<T> GetItemByFilterAsync(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();

    
}