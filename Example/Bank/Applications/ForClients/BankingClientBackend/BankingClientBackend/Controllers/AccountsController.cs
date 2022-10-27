using Microsoft.AspNetCore.Mvc;

namespace BankingClientBackend.Controllers;

public class AccountsController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}

public class BankingAccountSimple
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Balance { get; set; }
    public string Currency { get; set; } = null!;
    public bool IsDefault { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsArchived { get; set; }
    public string IsCurrencyType { get; set; } = null!;
    public string IsCurrencyTypeCode { get; set; } = null!;
    public bool IsDeleted { get; set; }
}

public class BankingAccountComplete: BankingAccountSimple
{
    public string AccountNumber { get; set; } = null!;
    public List<Transaction>? Transactions { get; set; }
}

public class Transaction
{
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public string Currency { get; set; } = null!;
    public string Type { get; set; } = null!;
    public bool IsBlocked { get; set; }
    public string RelatedTransactionAccountNumber { get; set; } = null!;
}