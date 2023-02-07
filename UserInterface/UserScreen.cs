using ShegeBank.ATM_Main;
using ShegeBank.Bank.AtmFunctionality;
using ShegeBank.LanguageChoice;

namespace ShegeBank.UserInterface;

internal class UserScreen
{
    public static void Welcome()
    {
        Console.Clear();
        Console.Title = "Shege Bank";
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("\n************************Welcome to Shege ATM... Nnoo...************************\n");
        Console.Write($"\nPress Enter to Continue...[Pia Enter obuna ichoro e ga n'iru]");
        Console.ReadLine();
    }
    internal static void LockAccount()
    {
        Console.Clear();
        Utility.Loading($"{Languages.Display(68)}", "<<<>>>", 6, 400);
        Utility.PrintMessage($"{Languages.Display(69)}", false);
        Utility.PressEnterToContinue();
        Utility.PrintMessage($"{Languages.Display(70)}", false);
        Utility.Loading("", "-_-", 6, 400);
        ALwaysOnScreen.Display();
    }

    internal static void LockedAccount()
    {
        Utility.PrintMessage(">Your account has been suspended... visit our nearest branch for futher information and actions...\n" +
                          "\n>>[Ya account don dey locked... go we closest office make we for open am]...\n" +
                          "\n>>>[Anyi akpochigo accounti gi... ga ulo oru anyi ebe ka gi nso ka anyi kponye ya]", false);
        Utility.PressEnterToContinue();
        Pick.Cancel();
    }
    internal static void AtmMenu()
    {
        Console.Clear();
        Utility.PrintMessage($"\n~~~~~~~~~~~~~~~~~~~~~~{Languages.Display(71)}~~~~~~~~~~~", true);
        Utility.PrintMessage("|___________________________________________________________| ", true);
        Utility.PrintMessage($"> 1. {Languages.Display(72)}", true);
        Utility.PrintMessage($"> 2. {Languages.Display(73)}", true);
        Utility.PrintMessage($"> 3. {Languages.Display(74)}", true);
        Utility.PrintMessage($"> 4. {Languages.Display(75)}", true);
        Utility.PrintMessage($"> 5. {Languages.Display(76)}", true);
        Utility.PrintMessage($"> 6. {Languages.Display(77)}", true);
        Utility.PrintMessage($"> 7. {Languages.Display(78)}", false);
        Utility.PrintMessage($"|___________________________________________________________|", false);
        Utility.PrintMessage($"|___________________________________________________________|", false);
        Utility.PrintMessage($"~~~~~~~~~~~~~~~~~~~~~~{Languages.Display(79)}~~~~~~~~~~~", true);
    }

    internal static void DisplayAtmMenu()
    {
        AtmMenu();
        Option.UserInput();
    }
    public static void WithdrawalOption()
    {
        Console.Clear();
        Utility.PrintMessage($"\n~~~~~~~~~~{Languages.Display(80)}~~~~~", true);
        Utility.PrintMessage("|_________________________________________________|", true);
        Utility.PrintMessage("| 1. 500                                2. 1,000  |", true);
        Utility.PrintMessage("| 3. 2,000                              4. 5,000  |", true);
        Utility.PrintMessage("| 5. 10,000                             6. 20,000 |", true);
        Utility.PrintMessage($"> 7. {Languages.Display(81)}", true);
        Utility.PrintMessage("|_________________________________________________|", false);
        Utility.PrintMessage("|_________________________________________________|", false);
        Utility.PrintMessage($"~~~~~~~~~~{Languages.Display(82)}~~~~~", true);
    }

    public static void AirtimeOption()
    {
        Console.Clear();
        Utility.PrintMessage($"\n~~~~~~~~~~{Languages.Display(83)}~~~~~", true);
        Utility.PrintMessage("|_________________________________________________|", true);
        Utility.PrintMessage("| 1. 200                                2. 500    |", true);
        Utility.PrintMessage("| 3. 1,000                              4. 2,000  |", true);
        Utility.PrintMessage($"> 5. {Languages.Display(81)}            ", true);
        Utility.PrintMessage("|_________________________________________________|", false);
        Utility.PrintMessage("|_________________________________________________|", false);
        Utility.PrintMessage($"~~~~~~~~~~{Languages.Display(82)}~~~~~", true);
    }

    public static void RechargeChoice()
    {
        Console.Clear();
        Utility.PrintMessage($"\n~~~~~~~~~~{Languages.Display(84)}~~~~~", true);
        Utility.PrintMessage("|_________________________________________________________|", true);
        Utility.PrintMessage($"> 1. {Languages.Display(85)}                     2. {Languages.Display(86)}", true);
        Utility.PrintMessage("|_________________________________________________________|", true);
        Utility.PrintMessage($"~~~~~~~~~~{Languages.Display(82)}~~~~~", true);
    }

    public static void LanguageChoice()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("|~~~~~~~~~~~~~~~Select language~~~~~~~~~~~~~~~|");
        Console.WriteLine("|_____________________________________________|");
        Console.WriteLine("| 1. English                                  |\n"+
                          "| 2. Pigin                                    |\n"+
                          "| 3. Igbo                                     |");
        Console.WriteLine("|_____________________________________________|");
        Console.WriteLine("|~~~~~~~~~~~~~~~~Select option~~~~~~~~~~~~~~~~|");
    }
}