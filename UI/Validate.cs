using System.ComponentModel;

namespace ShegeBank.UI;

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
                Utility.PrintMessage("Invalid Input...try again", false);
            }
        }
        return default;
    }
}