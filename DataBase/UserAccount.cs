namespace ShegeBank.DataBase;

internal class UserAccount
{
    public string? FullName { get; set; }
    public int Id { get; set; }
    public long AccountNumber { get; set; }
    public long CardNumber { get; set; }
    public int CardPin { get; set; }
    public decimal AccountBalance { get; set; }
    public decimal AmountWithdrawable { get; set; }
    public long MobileNumber { get; set; }
    public int TotalLogin { get; set; }
    public bool IsLocked { get; set; }
}