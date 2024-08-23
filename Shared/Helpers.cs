using MudBlazor;

namespace MedbaseComponents.Shared;

public class Helpers
{
    public static void ShowSnackbar(string message, Severity severity, ISnackbar Snackbar)
    {
        _ = Snackbar.Add(message, severity);
    }
    public static string OpenApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
}
