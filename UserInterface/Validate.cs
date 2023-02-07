using ShegeBank.LanguageChoice;
using System.ComponentModel;

namespace ShegeBank.UserInterface;

internal class Validate
{
    public static T Convert<T>(string prompt)
    {
        bool valid = true;
        string userInput;

        while (valid)
        {
            userInput = Utility.GetUserInput(prompt);

            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                    return (T)converter.ConvertFromString(userInput);
                else
                   
                    return default;
            }
            catch
            {
                Utility.PrintMessage($"{Languages.Display(3)}", false);
            }
        }
        return default;
    }
}