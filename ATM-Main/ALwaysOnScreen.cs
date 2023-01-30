using ShegeBank.Bank.AtmFunctionality;
using ShegeBank.UI;

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