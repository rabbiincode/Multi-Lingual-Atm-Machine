using ShegeBank.Bank;
using ShegeBank.UserInterface;

namespace ShegeBank.ATM_Main;

internal class ALwaysOnScreen
{
    internal static void Display()
    {
        Atm atm = new();
        UserScreen.Welcome();
        atm.ValidateCardNumberAndPassword();
        UserScreen.DisplayAtmMenu();
    }
}