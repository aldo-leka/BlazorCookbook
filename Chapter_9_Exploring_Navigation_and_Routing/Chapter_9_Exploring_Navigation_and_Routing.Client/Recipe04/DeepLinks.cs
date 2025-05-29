namespace Chapter_9_Exploring_Navigation_and_Routing.Client.Recipe04;

public static class DeepLinks
{
    public const string
        LandingPage = "/ch09r04",
        EventPage = "/ch09r04/{eventId:guid}",
        EventAtVenuePage =
            "/ch09r04/{eventId:guid}/venues/{venue?}";
    
    public static string GetPage(Guid eventId)
        => EventPage.Replace("{eventId:guid}", $"{eventId}");
}