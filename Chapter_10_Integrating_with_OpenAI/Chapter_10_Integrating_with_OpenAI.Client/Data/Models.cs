namespace Chapter_10_Integrating_with_OpenAI.Client.Data;

public class ClaimViewModel
{
    public string Event { get; set; }
    public string Date { get; set; }
    public CustomerViewModel Customer { get; set; } = new();
    public string Message { get; set; }
}

public class CustomerViewModel
{
    public string Name { get; set; }
    public string Email { get; set; }
}