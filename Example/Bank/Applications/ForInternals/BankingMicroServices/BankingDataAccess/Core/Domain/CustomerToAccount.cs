using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class CustomerToAccount: Entity
{
    public Guid CustomerId { get; set; }
    public Guid AccountId { get; set; }
}