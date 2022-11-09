using System.Linq.Expressions;
using BankingDataAccess.Core.BaseDomain;
using Microsoft.EntityFrameworkCore;

namespace BankingDataAccess.Core.Repositories;


public interface IRepository<TEntity> where TEntity : Entity, IEntity
{
    /*Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);*/

    IQueryable GetAll();
    TEntity Get(Guid id);
    IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}

