using ConsoleTables;
using ShegeBank.DataBase;
using ShegeBank.Enum;
using ShegeBank.UI;

namespace ShegeBank.Bank.AtmFunctionality;

internal partial class Atm
{
    public void Transfer()
    {
        ValidateTransfer();
    }

    public void ValidateTransfer()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        transfer: decimal transferAmount = Validate.Convert<decimal>("the amount you want to transfer");

        if (transferAmount <= 0)
        {
            Utility.PrintMessage("Amount must be greater than 0", false);
            Thread.Sleep(4000);
            goto transfer;
        }

        if (transferAmount >= UserData.selectedAccount.AmountWithdrawable)
        {
            Utility.PrintMessage("Insufficient fund", false);
            Utility.PressEnterToContinue();
            return;
        }

        startTransfer: long accountNumber = Validate.Convert<long>("the account number you want to transfer to");

        try
        {
            var validAccountNumber = (from number in UserData.UserAccountList
                                      where number.AccountNumber == accountNumber
                                      select number).First();

            UserData.transferAccount = validAccountNumber;
        }
        catch
        {
            Utility.PrintMessage("Account number invalid...please input a valid account number", false);
            Thread.Sleep(2000);
            goto startTransfer;
        }


        if (UserData.transferAccount.AccountNumber == UserData.selectedAccount.AccountNumber)
        {
            Utility.PrintMessage("Cannot transfer to your account...please input a valid account number", false);
            Thread.Sleep(2000);
            goto startTransfer;
        }

        Utility.Loading("Please wait while your transaction is processing", ".", 7, 500);

        Console.WriteLine($"Transfer {Utility.FormatCurrency(transferAmount)} to {UserData.transferAccount.FullName}");

        question: int answer = Validate.Convert<int>("1 to continue and 2 to terminate");

        if (answer == 2)
            return;

        if (answer <= 0 || answer > 2)
        {
            Utility.PrintMessage("Invalid option", false);
            goto question;
        }

        Utility.Loading("Please wait", ".", 6, 400);
        Utility.PrintMessage($"Transfer of {Utility.FormatCurrency(transferAmount)} to {UserData.transferAccount.FullName} was successful", true);
        Utility.PressEnterToContinue();

        //update senders balance
        UserData.selectedAccount.AccountBalance -= transferAmount;

        //update recievers balance
        UserData.transferAccount.AccountBalance += transferAmount;

        //update senders transaction history
        InsertTransaction(UserData.selectedAccount.Id, TransactionType.Transfer, Utility.FormatCurrency(transferAmount), $"Cash transfer to {UserData.transferAccount.FullName} at shege bank atm");

        //update recievers transaction history
        InsertTransaction(UserData.transferAccount.Id, TransactionType.Deposit, Utility.FormatCurrency(transferAmount), $"Cash transfer from {UserData.selectedAccount.FullName} at shege bank atm");
    }
    public void Airtime()
    {
        MobileNumberChoice();
        UserScreen.AirtimeOption();
        ValidateAirtime();
    }

    public void MobileNumberChoice()
    {
        UserScreen.RechargeChoice();
        option: int airtimeOption = Validate.Convert<int>("option");

        switch (airtimeOption)
        {
            case (int)MobileChoice.Self:
                selectedMobileNumber = UserData.selectedAccount.MobileNumber;
                break;
            case (int)MobileChoice.Others:
                selectedMobileNumber = Validate.Convert<long>("the mobile number you want to recharge");
                break;
            default:
                Utility.PrintMessage("Invalid input", false);
                goto option;
        }
    }
    public void ValidateAirtime()
    {
        option: int airtimeOption = Validate.Convert<int>("option");

        switch (airtimeOption)
        {
            case (int)Recharge.TwoHundred:
                OptionAirtime(200);
                break;
            case (int)Recharge.FiveHundred:
                OptionAirtime(500);
                break;
            case (int)Recharge.OneThousand:
                OptionAirtime(1000);
                break;
            case (int)Recharge.TwoThousand:
                OptionAirtime(2000);
                break;
            case (int)Recharge.Others:
                OtherAirtime();
                break;
            default:
                goto option;
        }
    }

    public void OptionAirtime(decimal airtimeAmount)
    {
        if (airtimeAmount >= UserData.selectedAccount?.AmountWithdrawable)
        {
            Utility.PrintMessage("Insufficient fund", false);
            Utility.PressEnterToContinue();
            return;
        }

        RechargeMessage(airtimeAmount);
    }
    public void OtherAirtime()
    {
        startRecharge: int otherRechargeAmount = Validate.Convert<int>("the amount you want to recharge");

        if (otherRechargeAmount <= 0)
        {
            Utility.PrintMessage("Amount must be greater than 0", false);
            Thread.Sleep(2000);
            goto startRecharge;
        }

        if (otherRechargeAmount > 20000)
        {
            Utility.PrintMessage($"You cannot recharge more than {Utility.FormatCurrency(20000)} at a time", false);
            Thread.Sleep(2000);
            goto startRecharge;
        }

        if (otherRechargeAmount >= UserData.selectedAccount?.AmountWithdrawable)
        {
            Utility.PrintMessage("Insufficient fund", false);
            Utility.PressEnterToContinue();
            return;
        }

        RechargeMessage(otherRechargeAmount);
    }

    public void RechargeMessage(decimal amount)
    {
        Utility.Loading("Please wait", ".", 6, 500);

        Console.WriteLine($"Recharge mobile no : {selectedMobileNumber} with {Utility.FormatCurrency(amount)}");
        Thread.Sleep(3000);
        Console.Write("Do you wish to continue? ");
        question: int answer = Validate.Convert<int>("1 to continue and 2 to terminate");

        if (answer == 2)
            return;

        if (answer <= 0 || answer > 2)
        {
            Utility.PrintMessage("Invalid option", false);
            goto question;
        }

        Utility.Loading("", "", 5, 500);
        Utility.PrintMessage($"Mobile no : {selectedMobileNumber} has been recharged with {Utility.FormatCurrency(amount)} successfully", true);
        Utility.PressEnterToContinue();

        UserData.selectedAccount.AccountBalance -= amount;

        InsertTransaction(UserData.selectedAccount.Id, TransactionType.Airtime, Utility.FormatCurrency(amount), $"Airtime top-up at shege bank atm");
    }

    public void InsertTransaction(int userBankAccountId, TransactionType transactionType, string amount, string description)
    {
        var tracker = new TransactionTracker
        {
            TransactionId = Utility.GenerateTransactionId(),
            UserBankAccountId = userBankAccountId,
            TransactionType = transactionType,
            TransactionAmount = amount,
            TransactionDate = DateTime.Now,
            Description = description
        };
        UserData.TransactionTrackerList.Add(tracker);
    }

    public void ViewTransaction()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        var filteredList = from list in UserData.TransactionTrackerList
                           where list.UserBankAccountId == UserData.selectedAccount.Id
                           select list;

        var count = filteredList.Count();

        if (count > 0)
        {
            ConsoleTable table = new("Id", "Transaction Date", "Type", "Amount", "Description");

            foreach (var display in filteredList)
            {
                table.AddRow(display.TransactionId, display.TransactionDate, display.TransactionType, display.TransactionAmount, display.Description);
            }
            table.Options.EnableCount = false;
            table.Write();

            Utility.PrintMessage($"No of transaction(s) : {count}", true);
        }
        else
            Utility.PrintMessage("You have no transaction(s) yet", false);

        Utility.PressEnterToContinue();
    }
}