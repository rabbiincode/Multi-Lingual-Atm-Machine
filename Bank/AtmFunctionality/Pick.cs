using ShegeBank.ATM_Main;
using ShegeBank.LanguageChoice;
using ShegeBank.UserInterface;

namespace ShegeBank.Bank.AtmFunctionality;
internal class Pick
{
    public static void Question()
    {
        Utility.Loading("", ".", 6, 300);
        Console.Write($"{Languages.Display(64)}");
        exit: int pick = Validate.Convert<int>($"{Languages.Display(65)}");
        switch (pick)
        {
            case 1:
                UserScreen.DisplayAtmMenu();
                break;
            case 2:
                Cancel();
                break;
            default:
                Utility.PrintMessage($"{Languages.Display(3)}", false);
                goto exit;
        }
    }
    public static void Cancel()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Clear();
        Utility.Loading("", "___", 5, 500);
        Utility.Loading($"---------------{Languages.Display(66)}---------------", "", 6, 400);
        Utility.Loading($"---------------{Languages.Display(67)}---------------", "", 6, 500);
        ALwaysOnScreen.Display();
    }
}