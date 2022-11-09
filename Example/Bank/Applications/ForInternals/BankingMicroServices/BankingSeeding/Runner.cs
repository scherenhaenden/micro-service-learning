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
        
        var addUsers = new AddUsers();

        var users = addUsers.GetFirstUsers();

        foreach (var item in users)
        {
            uow.Users.Add(item.Item1);
            uow.Roles.Add(item.Item2);  
            uow.Tokens.Add(item.Item3);
        }
        uow.Complete();
    }
    
}