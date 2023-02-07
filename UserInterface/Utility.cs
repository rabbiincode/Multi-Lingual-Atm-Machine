using ShegeBank.LanguageChoice;
using System.Globalization;
using System.Text;

namespace ShegeBank.UserInterface;

internal class Utility
{    
    public static string GetUserInput(string prompt)
    {
        Console.Write($"\n{prompt} : ");
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
    }
    public static void PressEnterToContinue()
    {
        Console.Write($"\n{Languages.Display(0)}");
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
                    PrintMessage($"\n{Languages.Display(1)}", false);
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
            PrintMessage($"\n{Languages.Display(2)}", false);
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