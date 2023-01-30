using ShegeBank.DataBase;
using ShegeBank.Enum;
using ShegeBank.Interfaces;
using ShegeBank.UI;

namespace ShegeBank.Bank.AtmFunctionality;

internal partial class Atm : IUserLogin, IUserMainOptions, ITrackTransaction
{
    private decimal minimumBalance = 500;
    private decimal maximumWithdrawalAmount = 40000;
    long selectedMobileNumber;
    public void ValidateCardNumberAndPassword()
    {
        UserData.InitializeData();

        bool login = false;
        long cardNumber = Validate.Convert<long>("your card number");

        while (login == false)
        {
            Utility.Loading("Please wait", ".", 6, 500);
            try
            {
                var accountSelected = (from account in UserData.UserAccountList
                                       where account.CardNumber == cardNumber
                                       select account).First();

                UserData.selectedAccount = accountSelected;
            }
            catch
            {
                Utility.PrintMessage("Your ATM card is invalid", false);
                Thread.Sleep(4000);
                Pick.Cancel();
                login = true;
                break;
            }

            UserData.selectedAccount.AmountWithdrawable = UserData.selectedAccount.AccountBalance - minimumBalance;

            if (UserData.selectedAccount.IsLocked == true)
            {
                UserScreen.LockedAccount();
                login = true;
                break;
            }

            inputPin: int pin = Utility.GetUserPin("Enter your pin");

            if (pin == UserData.selectedAccount.CardPin)
            {
                Utility.Loading("Please wait", ".", 6, 500);

                Utility.PrintMessage($"Hello {UserData.selectedAccount.FullName}, welcome back", true);
                Thread.Sleep(2000);
                UserData.selectedAccount.TotalLogin = 0;
                login = true;
                break;
            }
            else
            {
                Utility.PrintMessage("\nIncorrect pin...please try again", false);
                UserData.selectedAccount.TotalLogin++;

                if (UserData.selectedAccount.TotalLogin == 2)
                {
                    Utility.PrintMessage("Your account will be locked on the third wrong attempt", false);
                    Thread.Sleep(4000);
                }

                if (UserData.selectedAccount.TotalLogin == 3)
                {
                    Thread.Sleep(2000);
                    UserData.selectedAccount.IsLocked = true;
                    UserScreen.LockAccount();
                    login = true;
                    break;
                }
                goto inputPin;
            }

        }
    }
    public void CheckBalance()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Utility.Loading("Please wait", ".", 6, 500);
        Console.WriteLine($"| Account balance : {Utility.FormatCurrency(UserData.selectedAccount.AccountBalance)} |");
        Utility.PressEnterToContinue();
    }
    public void Deposit()
    {
        ValidateDeposit();
    }

    public void ValidateDeposit()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        startDeposit: Utility.PrintMessage("Deposit must be made in multiples of 500 and 1000 only", false);
        Utility.PressEnterToContinue();
        decimal depositAmount = Validate.Convert<decimal>("the amount you want to deposit");

        if (depositAmount % 500 != 0 || depositAmount == 0)
            goto startDeposit;

        decimal thousandCount = depositAmount / 1000;
        decimal hundredCount = (depositAmount % 1000) / 500;

        Thread.Sleep(2000);
        Utility.PrintMessage("Please ensure that cash loaded into the machine are ONLY in multiple of 500 and 1000" +
                            " \nas the atm cannot dispense back non-multiples once loaded and will not validate them", false);
        Utility.PressEnterToContinue();
        Utility.Loading("Please load your cash in the atm's cash collector", "<<", 7, 800);
        Utility.Loading("Validating cash...please wait", ".", 6, 500);
        Utility.Loading("Counting cash", ".", 7, 600);


        Console.WriteLine("------------------Deposit Summary------------------");
        if (depositAmount == 500)
        {
            Console.WriteLine($">500 X {hundredCount} = {Utility.FormatCurrency(500 * hundredCount)}");
        }
        else if (depositAmount % 1000 == 0)
        {
            Console.WriteLine($">1000 X {thousandCount} = {Utility.FormatCurrency(depositAmount)}");
        }
        else
        {
            Console.WriteLine($">1000 X {(int)thousandCount} = {Utility.FormatCurrency(1000 * (int)thousandCount)}");
            Console.WriteLine($">500 X {hundredCount} = {Utility.FormatCurrency(500 * hundredCount)}");
        }
        Console.WriteLine($"\nTotal : {Utility.FormatCurrency(depositAmount)}");
        Console.WriteLine("---------------------------------------------------");

        Utility.PressEnterToContinue();

        Utility.PrintMessage($"Your deposit of {Utility.FormatCurrency(depositAmount)} was successful", true);
        Utility.PressEnterToContinue();
        UserData.selectedAccount.AccountBalance += depositAmount;

        InsertTransaction(UserData.selectedAccount.Id, TransactionType.Deposit, Utility.FormatCurrency(depositAmount), "Cash deposit at shege bank atm");
    }
    public void Withdrawal()
    {
        UserScreen.WithdrawalOption();
        ValidateWithdrawal();
    }

    public void ValidateWithdrawal()
    {
        option: int withdrawalOption = Validate.Convert<int>("option");

        switch (withdrawalOption)
        {
            case (int)Withdraw.FiveHundred:
                OptionWithdrawal(500);
                break;
            case (int)Withdraw.OneThousand:
                OptionWithdrawal(1000);
                break;
            case (int)Withdraw.TwoThousand:
                OptionWithdrawal(2000);
                break;
            case (int)Withdraw.FiveThousand:
                OptionWithdrawal(5000);
                break;
            case (int)Withdraw.TenThousand:
                OptionWithdrawal(10000);
                break;
            case (int)Withdraw.TwentyThousand:
                OptionWithdrawal(20000);
                break;
            case (int)Withdraw.Others:
                OtherWithdrawal();
                break;
            default:
                Utility.PrintMessage("Invalid input...please select any option", false);
                goto option;
        }
    }
    public void OptionWithdrawal(decimal withdrawalAmount)
    {
        if (withdrawalAmount >= UserData.selectedAccount?.AmountWithdrawable)
        {
            Utility.PrintMessage("Insufficient fund", false);
            Utility.PressEnterToContinue();
            return;
        }

        WithdrawalMessage(withdrawalAmount);
    }
    public void OtherWithdrawal()
    {
        startWithdrawal: int otherWithdrawalAmount = Validate.Convert<int>("the amount you want to withdraw");

        if (otherWithdrawalAmount <= 0)
        {
            Utility.PrintMessage("Amount must be greater than 0", false);
            goto startWithdrawal;
        }

        if (otherWithdrawalAmount % 500 != 0)
        {
            Utility.PrintMessage("Amount must be in multiples of 500 and 1000", false);
            goto startWithdrawal;
        }
            
        if (otherWithdrawalAmount >= UserData.selectedAccount?.AmountWithdrawable)
        {
            Utility.PrintMessage("Insufficient fund", false);
            Utility.PressEnterToContinue();
            return;
        }

        if (otherWithdrawalAmount > maximumWithdrawalAmount)
        {
            Utility.PrintMessage($"Cannot withdraw more than {Utility.FormatCurrency(maximumWithdrawalAmount)}", false);
            goto startWithdrawal;
        }

        WithdrawalMessage(otherWithdrawalAmount);
    }

    public void WithdrawalMessage(decimal amount)
    {
        Utility.Loading("Please wait", ".", 6, 500);
        Utility.Loading("...........Please Note - The atm does not take back cash after despensing...........", "", 6, 400);

        Utility.PrintMessage($"Your withdrawal of {Utility.FormatCurrency(amount)} was successful", true);
        Utility.Loading("","", 5, 500);
        Utility.PrintMessage("Please take your cash", true);
        Thread.Sleep(4000);

        UserData.selectedAccount.AccountBalance -= amount;

        InsertTransaction(UserData.selectedAccount.Id, TransactionType.Withdrawal, Utility.FormatCurrency(amount), "Cash withdrawal at shege bank atm");
    }
}