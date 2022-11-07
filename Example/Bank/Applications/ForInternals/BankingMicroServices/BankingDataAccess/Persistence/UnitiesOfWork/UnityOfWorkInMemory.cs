using BankingDataAccess.Core.BaseDomain;
using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Repositories;
using BankingDataAccess.Persistence.Repositories;

namespace BankingDataAccess.Persistence.UnitiesOfWork;

public class GenericUnitOfWork<TRepo, TEntity> : IDisposable, IUnityOfWork<TEntity>
    where TRepo : Repository<TEntity> where TEntity: Entity, IEntity
{
    // Initialization code

    public Dictionary<Type, TRepo> repositories = new Dictionary<Type, TRepo>();
    private IRepository<TEntity> _repository;

    public TRepo Repository()
    {
        if (repositories.Keys.Contains(typeof(TEntity)) == true)
        {
            return repositories[typeof(TEntity)];
        }
        TRepo repo = (TRepo)Activator.CreateInstance(
            typeof(TRepo),
            new object[] { /*put there parameters to pass*/ });
        repositories.Add(typeof(TEntity), repo);
        return repo;
    }

    // other methods
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    IRepository<TEntity> IUnityOfWork<TEntity>.Repository => _repository;

    public void Save()
    {
        throw new NotImplementedException();
    }
}


public class UnityOfWorkInMemory<TEntity>: IUnityOfWork<TEntity> where TEntity: Entity, IEntity
{
    private GenericContext _context;
    
    public UnityOfWorkInMemory(GenericContext context)
    {
        _context = context;
    }
    
    public Dictionary<Type, TEntity> repositories = new Dictionary<Type, TEntity>();


    
    
    public IRepository<TEntity> Repository { get; }
    public void Save()
    {
        _context.SaveChanges();
    }
}