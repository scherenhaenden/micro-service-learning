using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class Transactions: Entity
{ 
    public Guid TransactionTypeId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateOfTheTransaction { get; set; }
    public string Description { get; set; }
    public string Iban { get; set; }
    public string IbanRelated { get; set; }
}