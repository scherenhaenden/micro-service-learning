using BankingDataAccess.Core.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BankingSeeding.DataAccess;

public class DbInitiator
{
    /*public static void Initiate()
    {
        using var context = new BankingContext();
        context.Database.Migrate();
    }*/
    
    public GenericContext GetInMemoryContext()
    {
        return new ContextGenerator().GetContextInMemory();
    }
    
    public GenericContext GetSqliteContext()
    {
        return new ContextGenerator().GetContextSqlite();
    }
}

public class ContextGenerator
{
    /*public static BankingSeedingContext GetContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<BankingSeedingContext>();
        optionsBuilder.UseSqlServer("Server=.;Database=BankingSeeding;Trusted_Connection=True;MultipleActiveResultSets=true");
        return new BankingSeedingContext(optionsBuilder.Options);
    }*/
    
    // Add method to get generate memory database
    public GenericContext GetContextInMemory()
    {
        var optionsBuilder = new DbContextOptionsBuilder<GenericContext>();
        optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("BankingSeeding");
        return new GenericContext(optionsBuilder.Options);
    }
    
    // Add method to get generate sqlite database
    public GenericContext GetContextSqlite()
    {
        var optionsBuilder = new DbContextOptionsBuilder<GenericContext>();
        optionsBuilder.UseLazyLoadingProxies().UseSqlite("Data Source=../../../../../../../Data/BankingSeeding.db");
        return new GenericContext(optionsBuilder.Options);
    }
}