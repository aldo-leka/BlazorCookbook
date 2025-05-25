using System.Text.Json;
using System.Text.Json.Serialization;

namespace Chapter_6_Building_Interactive_Forms.Client.Data;

public record Event
{
    public string Name { get; set; }
    public EventPeriod Period { get; set; } = new();

    public bool IsActive { get; set; }
    public string Location { get; set; }
    public int Capacity { get; set; }
    public EventType Type { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public string Json => JsonSerializer.Serialize(this);
}

public record EventPeriod
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}

public enum EventType
{
    Conference,
    Seminar,
    Workshop
}

public static class EventVenues
{
    public static readonly string[] All = ["South hall", "Main hall", "Garden"];
}