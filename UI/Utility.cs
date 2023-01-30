using System.Globalization;
using System.Text;

namespace ShegeBank.UI;

internal class Utility
{
    public static string GetUserInput(string prompt)
    {
        Console.Write($"\nEnter {prompt} : ");
        string? input = Console.ReadLine();
        return input;
    }
    public static void PrintMessage(string message, bool status)
    {
        if (status == true)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
        //PressEnterToContinue();
    }
    public static void PressEnterToContinue()
    {
        Console.Write("\nPress Enter to Continue");
        Console.ReadLine();
    }
    public static int GetUserPin(string prompt)
    {
        bool isPrompt = true;
        string hashPin = "";
        int pin;

        //stores key input from the console
        StringBuilder input = new StringBuilder();

        start: while (true)
        {
            if (isPrompt)
                Console.Write($"{prompt} : ");
             isPrompt = false;
            
            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.Enter)
            {
                if (input.Length == 4)
                {
                    break;
                }
                else
                {
                    PrintMessage("\nInvalid pin...enter your 4 digit pin", false);
                    input.Clear();
                    isPrompt = true;
                    continue;
                }
            }

            if (inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input.Remove(input.Length - 1, 1);
            }
            else if (inputKey.Key != ConsoleKey.Backspace)
            {
                input.Append(inputKey.KeyChar);
                //Returns hidden pin characters as the user types
                Console.Write($"{hashPin}* ");
            }
        }

        bool success = int.TryParse(input.ToString(), out pin);
        if (success == false)
        {
            PrintMessage("\nPin not in correct format...enter your 4 digit number", false);
            isPrompt = true;
            goto start;
        }
        return pin;
       
    }

    public static void Loading(string holdOn, string load, int count, int timer)
    {
        Console.Write($"\n{holdOn}");
        for (int i = 0; i < count; i++)
        {
            Console.Write($"{load}");
            Thread.Sleep(timer);
        }
        Console.Clear();
        //PressEnterToContinue();
    }

    private static CultureInfo culture = new CultureInfo("en-US");
    public static string FormatCurrency(decimal amount)
    {
        return String.Format(culture, "{0:c2}", amount);
    }

    private static long generateTransactionId;
    public static long GenerateTransactionId()
    {
        return ++generateTransactionId;
    }
}