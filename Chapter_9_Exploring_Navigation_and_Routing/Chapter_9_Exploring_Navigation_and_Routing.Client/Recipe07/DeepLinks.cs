namespace Chapter_9_Exploring_Navigation_and_Routing.Client.Recipe07;

public static class DeepLinks
{
    public const string
        LandingPage = "/ch09r07",
        EventPage = "/ch09r07/{eventId:guid}",
        EventAtVenuePage =
            "/ch09r07/{eventId:guid}/venues/{venue?}";
    
    public static string GetPage(Guid eventId)
        => EventPage.Replace("{eventId:guid}", $"{eventId}");
}