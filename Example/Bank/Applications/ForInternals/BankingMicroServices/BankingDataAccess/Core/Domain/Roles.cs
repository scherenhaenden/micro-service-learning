using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class Roles: Entity
{
    public string RoleName { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}