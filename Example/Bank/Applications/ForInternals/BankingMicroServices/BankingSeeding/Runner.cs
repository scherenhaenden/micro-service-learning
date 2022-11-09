using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Persistence.UnitiesOfWork;
using BankingSeeding.DataAccess;
using BankingSeeding.DataSeeding;

namespace BankingSeeding;

public class Runner
{
    public void Run()
    {
        // Get DB initiator
        var dbInitiator = new DbInitiator();

        var context = dbInitiator.GetSqliteContext();
        
        IUnitOfWorkV2 uow = new UnityOfWorkV2(context);
        
        // Create a new user
        var users = new AddUsers().GetUsers();
        uow.Users.AddRange(users);
        uow.Complete();
    }
    
}