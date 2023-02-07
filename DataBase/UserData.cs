using ShegeBank.Models;

namespace ShegeBank.DataBase;

internal class UserData
{
    internal static List<UserAccount> UserAccountList;
    internal static UserAccount selectedAccount;
    internal static UserAccount transferAccount;
    internal static List<TransactionTracker> TransactionTrackerList = new List<TransactionTracker>();
    public static void InitializeData()
    {
        UserAccountList = new List<UserAccount>
        {
            new UserAccount{ Id = 1, FullName = "Adam Gray", AccountNumber = 2234567890, CardNumber = 987654, AccountBalance = 15000, CardPin = 4444, IsLocked = false, MobileNumber = 08086757326 },
            new UserAccount{ Id = 2, FullName = "John Len", AccountNumber = 2489975191, CardNumber = 123456, AccountBalance = 5000, CardPin = 3333, IsLocked = true, MobileNumber = 07056483547 },
            new UserAccount{ Id = 3, FullName = "Sarah White", AccountNumber = 2805598895, CardNumber = 227455, AccountBalance = 8000, CardPin = 5555, IsLocked = false, MobileNumber = 08054556789 },
            new UserAccount{ Id = 4, FullName = "Don Bill", AccountNumber = 2690454433, CardNumber = 667902, AccountBalance = 1000000, CardPin = 7777, IsLocked = false, MobileNumber = 08123567432 },
            new UserAccount{ Id = 5, FullName = "Jay White", AccountNumber = 2678532354, CardNumber = 654321, AccountBalance = 50000, CardPin = 2222, IsLocked = false, MobileNumber =09059585877 },
        };
    }
}