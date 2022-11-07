namespace BankingDataAccess.Core.BaseDomain;

public class Entity : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDateTime { get; set; }
    
    public DateTime? ModifiedDateTime { get; set; }
}