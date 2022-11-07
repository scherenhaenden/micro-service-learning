using System.Linq.Expressions;
using BankingDataAccess.Core.BaseDomain;
using BankingDataAccess.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankingDataAccess.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, IEntity
{
    private readonly DbContext _context;
    private DbSet<TEntity> _entities;
    public Repository(DbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }


    public IQueryable GetAll()
    {
        return _entities.AsQueryable();
    }

    public TEntity Get(Guid id)
    {
        return _entities.Single(x=>x.Id == id);
    }

    public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return _entities.Where(predicate);
    }

    public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return _entities.SingleOrDefault(predicate);
    }

    public void Add(TEntity entity)
    {
        _entities.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        _entities.AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        _entities.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _entities.RemoveRange(entities);
    }
}