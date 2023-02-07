using ShegeBank.Enum;
using ShegeBank.LanguageChoice;
using ShegeBank.UserInterface;

namespace ShegeBank.Bank.AtmFunctionality;
internal class Option
{
    public static void UserInput()
    {
        Atm atm= new();

        start: int input = Validate.Convert<int>($"{Languages.Display(63)}");

        switch (input)
        {
            case (int)UserChoice.CheckBalance:
                atm.CheckBalance();
                Pick.Question();
                break;
            case (int)UserChoice.Deposit:
                atm.Deposit();
                Pick.Question();
                break;
            case (int)UserChoice.Withdrawal:
                atm.Withdrawal();
                Pick.Question();
                break;
            case (int)UserChoice.Transfer:
                atm.Transfer();
                Pick.Question();
                break;
            case (int)UserChoice.Airtime:
                atm.Airtime();
                Pick.Question();
                break;
            case (int)UserChoice.TransactionHistory:
                atm.ViewTransaction();
                Pick.Question();
                break;
            case (int)UserChoice.Cancel:
                Pick.Question();
                break;
            default:
                Utility.PrintMessage($"{Languages.Display(3)}", false);
                goto start;
        }
    }
}