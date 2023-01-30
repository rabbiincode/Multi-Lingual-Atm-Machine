using ShegeBank.ATM_Main;
using ShegeBank.Bank.AtmFunctionality;

namespace ShegeBank.UI;

internal class UserScreen
{
    public static void Welcome()
    {
        Console.Clear();
        Console.Title = "Shege Bank";
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("\n************************Welcome to Shege ATM************************\n");
        Utility.PressEnterToContinue();
    }
    internal static void LockAccount()
    {
        Console.Clear();
        Utility.Loading("\nMaximum pin trial exceeded", "<<<>>>", 6, 400);
        Utility.PrintMessage("For security purposes, your Account has been suspended... visit our nearest branch for futher information and actions.", false);
        Utility.PressEnterToContinue();
        Utility.PrintMessage("\nYour Card has been withheld", false);
        Utility.Loading("", "-_-", 6, 400);
        ALwaysOnScreen.Display();
    }

    internal static void LockedAccount()
    {
        Utility.PrintMessage("Your account has been suspended... visit our nearest branch for futher information and actions.", false);
        Utility.PressEnterToContinue();
        Pick.Cancel();
    }
    internal static void AtmMenu()
    {
        Console.Clear();
        Utility.PrintMessage("\n|~~~~~~~What do you want to do?~~~~~~~|", true);
        Utility.PrintMessage("|                                     |", true);
        Utility.PrintMessage("|1. Account Balance                   |", true);
        Utility.PrintMessage("|2. Cash Deposit                      |", true);
        Utility.PrintMessage("|3. Withdrawal                        |", true);
        Utility.PrintMessage("|4. Transfer                          |", true);
        Utility.PrintMessage("|5. Airtime                           |", true);
        Utility.PrintMessage("|6. Transaction History               |", true);
        Utility.PrintMessage("|7. Cancel                            |", false);
        Utility.PrintMessage("|_____________________________________|", false);
        Utility.PrintMessage("|_____________________________________|", false);
        Utility.PrintMessage("|~~~~~~~~~~~~Select number~~~~~~~~~~~~|", true);
    }

    internal static void DisplayAtmMenu()
    {
        AtmMenu();
        Option.UserInput();
    }
    public static void WithdrawalOption()
    {
        Console.Clear();
        Utility.PrintMessage("\n|~~How much do you want to withdraw?~~|", true);
        Utility.PrintMessage("|                                     |", true);
        Utility.PrintMessage("| 1. 500                    2. 1,000  |", true);
        Utility.PrintMessage("| 3. 2,000                  4. 5,000  |", true);
        Utility.PrintMessage("| 5. 10,000                 6. 20,000 |", true);
        Utility.PrintMessage("| 7. Other Amounts                    |", true);
        Utility.PrintMessage("|_____________________________________|", false);
        Utility.PrintMessage("|_____________________________________|", false);
        Utility.PrintMessage("|~~~~~~~~~~~~Select option~~~~~~~~~~~~|", true);
    }

    public static void AirtimeOption()
    {
        Console.Clear();
        Utility.PrintMessage("\n|~~How much do you want to recharge?~~|", true);
        Utility.PrintMessage("|                                       |", true);
        Utility.PrintMessage("| 1. 200                      2. 500    |", true);
        Utility.PrintMessage("| 3. 1,000                    4. 2,000  |", true);
        Utility.PrintMessage("| 5. Other Amounts                      |", true);
        Utility.PrintMessage("|_______________________________________|", false);
        Utility.PrintMessage("|_______________________________________|", false);
        Utility.PrintMessage("|~~~~~~~~~~~~~Select option~~~~~~~~~~~~~|", true);
    }

    public static void RechargeChoice()
    {
        Console.Clear();
        Utility.PrintMessage("\n|~~~Who do you want to recharge for?~~~~|", true);
        Utility.PrintMessage("|                                       |", true);
        Utility.PrintMessage("| 1. Self                     2. Others |", true);
        Utility.PrintMessage("|_______________________________________|", true);
        Utility.PrintMessage("|~~~~~~~~~~~~~Select option~~~~~~~~~~~~~|", true);
    }
}