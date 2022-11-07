using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class CustomerToAddressId: Entity
{
    public Guid CustomerId { get; set; }
    public Guid AddressId { get; set; }
}