using BankingDataAccess.Core.BaseDomain;
using BankingDataAccess.Core.Repositories;

namespace BankingDataAccess.Core.Configuration;

public interface IUnityOfWork<T> where T : Entity, IEntity
{
    IRepository<T> Repository { get; }
    void Save();
}