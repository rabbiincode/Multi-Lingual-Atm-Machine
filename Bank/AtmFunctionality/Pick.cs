using ShegeBank.ATM_Main;
using ShegeBank.UI;

namespace ShegeBank.Bank.AtmFunctionality;
internal class Pick
{
    public static void Question()
    {
        Utility.Loading("", ".", 6, 300);
        Console.Write("Do you want to perform another transaction? ");
        exit: int pick = Validate.Convert<int>("1 if yes or 2 if no");
        switch (pick)
        {
            case 1:
                UserScreen.DisplayAtmMenu();
                break;
            case 2:
                Cancel();
                break;
            default:
                Utility.PrintMessage("Invalid input... try again", false);
                goto exit;
        }
    }
    public static void Cancel()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Clear();
        Utility.Loading("", "___", 5, 500);
        Utility.Loading("---------------Have a nice day---------------\n" +
                        "---------------Please take your card---------------", "", 6, 500);
        ALwaysOnScreen.Display();
    }
}