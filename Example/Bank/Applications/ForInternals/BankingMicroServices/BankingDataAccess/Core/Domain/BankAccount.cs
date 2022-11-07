using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class BankAccount: Entity
{
    public string Iban { get; set; }
    public int AccountTypeId { get; set; }
    public decimal Balance { get; set; }
    public Guid CustomerToAccountId { get; set; }
    public bool IsActive { get; set; }
    public int CurrencyId { get; set; }
}