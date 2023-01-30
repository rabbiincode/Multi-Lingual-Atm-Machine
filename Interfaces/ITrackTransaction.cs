using ShegeBank.Enum;

namespace ShegeBank.Interfaces;

public interface ITrackTransaction
{
    void InsertTransaction(int userBankAccountId, TransactionType transactionType, string amount, string description);
    void ViewTransaction();
}