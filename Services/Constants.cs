namespace MedbaseComponents.Services
{
    public static class Constants
    {
        public static double WeeklyAmount() => 1500;
        public static double MonthlyAmount() => 3500;
        //Preference strings
        public static string SubscriptionPreferenceDate() => "subscriptionEndDate";
        public static string SentryDsn = "https://a2d86a9dc6351f8ae17f6b7aecdd4251@o4505919081873408.ingest.sentry.io/4505919117656064";
        public static string ApplicationId() => "com.tanakamawere.medbasehybrid";
        public static string apiUrl = "https://apimedbase.azurewebsites.net/";
        //public static string apiUrl = "http://localhost:5249/";
        //public static string apiUrl = "http://10.0.2.2:5249/";
        public static string GoToMedbaseLink(string page) => $"http://medbase.co.zw/{page}";
        public static string LinkToWhatsApp = "https://wa.me/263785468923";
        public static string LinkToMyWebsite = "https://www.tanakamawere.co.zw";
        public static string LinkToMyEmail = "mailto:tanaka@tanakamawere.co.zw";

        //For Blazor Website
        public static string Theme(string theme) => theme;

        public static Dictionary<string, int> SearchCategories = new()
        {
            {"Search by Id", 1},
            {"Search by Keywords", 2 }
        };
    }
}
