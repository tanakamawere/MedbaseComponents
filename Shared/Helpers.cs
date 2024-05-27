using MudBlazor;

namespace MedbaseComponents.Shared;

public class Helpers
{
    public static void ShowSnackbar(string message, Severity severity, ISnackbar Snackbar)
    {
        _ = Snackbar.Add(message, severity);
    }

    public const string OpenApiKey = "sk-proj-TDpIjDYixkMzB5lrg3w3T3BlbkFJThgy58nKxGgauOeEkG4Y";
}
