using Microsoft.EntityFrameworkCore;

namespace BankingDataAccess.Core.Configuration;

public class GenericContext: DbContext
{
    public GenericContext(DbContextOptions<GenericContext> options) : base(options)
    {
    }
}