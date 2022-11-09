using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class Tokens: Entity
{
    public string Token { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? TokenName { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}