using BankingDataAccess.Core.BaseDomain;
using BankingDataAccess.Core.Domain;
using BankingDataAccess.Core.Repositories;

namespace BankingDataAccess.Core.Configuration;

public interface IUnityOfWork<T> where T : Entity, IEntity
{
    IRepository<T> Repository { get; }
    void Save();
}

public interface IUnitOfWorkV2: IDisposable
{

    IRepository<AccountTypes> AccountTypes { get; }
    
    IRepository<Addresses> Addresses { get; }
    
    IRepository<BankAccount> BankAccounts { get; }
    
    IRepository<Currency> Currencies { get; }
    
    IRepository<Customer> Customers { get; }
    
    IRepository<CustomersToAddresses> CustomersToAddresses { get; }
    
    IRepository<CustomerToBankAccount> CustomersBankAccounts { get; }
    
    IRepository<Transactions> Transactions { get; }

    IRepository<TransactionTypes> TransactionTypes { get; }
    
    IRepository<Users> Users { get; }
    int Complete();
}