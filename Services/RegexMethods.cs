using System.Text.RegularExpressions;

namespace MedbaseComponents.Services;

public static class RegexMethods
{
    //method to check if username is valid. It should contain letters and underscore and fullstops only
    public static bool IsValidUsername(string username)
    {
        Regex regex = new(@"^[a-zA-Z0-9_.]+$");
        return regex.IsMatch(username);
    }

    //method to check if phone number is valid. It should contain only numbers and should be 10 digits long
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        Regex regex = new(@"^[0-9]{10}$");
        return regex.IsMatch(phoneNumber);
    }
}
