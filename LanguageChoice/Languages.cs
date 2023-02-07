using ShegeBank.Enum;
using ShegeBank.UserInterface;

namespace ShegeBank.LanguageChoice;

internal partial class Languages
{
    static int input;
    public static void ValidateLanguageChoice()
    {
        UserScreen.LanguageChoice();
        start: input = Validate.Convert<int>("Enter your preferred language...[Tinye asusu e choro]");

        if (input <= 0 || input > 3)
        {
            Utility.PrintMessage("Enter a valid option...[Tinye nke e horo]", false);
            goto start;
        }
        Console.Clear();
    }
    public static string Display(int choose)
    {
        switch (input)
        {
            case (int)Language.English:
                return language[0, choose];
            case (int)Language.Pigin:
                return language[1, choose];
            case (int)Language.Igbo:
                return language[2, choose];
        }
        return language[input, choose];
    }
}