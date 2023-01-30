using ShegeBank.Enum;

namespace ShegeBank.Bank;
internal class TransactionTracker
{
    public long TransactionId { get; set; }
    public int UserBankAccountId { get; set; }
    public DateTime TransactionDate { get; set; }
    public string? TransactionAmount { get; set; }
    public TransactionType TransactionType { get; set; }
    public string? Description { get; set; }
}