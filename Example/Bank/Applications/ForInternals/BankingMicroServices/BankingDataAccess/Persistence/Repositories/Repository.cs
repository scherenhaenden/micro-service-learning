using System.Linq.Expressions;
using BankingDataAccess.Core.BaseDomain;
using BankingDataAccess.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankingDataAccess.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, IEntity
{
    private readonly DbContext _context;
    public DbSet<TEntity> Entity { get; }
    public Repository(DbContext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }


    public IQueryable GetAll()
    {
        return Entity.AsQueryable();
    }

    public TEntity Get(Guid id)
    {
        return Entity.Single(x=>x.Id == id);
    }

    public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return Entity.Where(predicate);
    }

    public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return Entity.SingleOrDefault(predicate);
    }

    public void Add(TEntity entity)
    {
        Entity.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        Entity.AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Entity.RemoveRange(entities);
    }
}