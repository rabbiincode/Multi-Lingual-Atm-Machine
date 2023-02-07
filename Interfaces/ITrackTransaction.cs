namespace ShegeBank.Interfaces;

public interface ITrackTransaction
{
    void InsertTransaction(int userBankAccountId, string transactionType, string amount, string description);
    void ViewTransaction();
}