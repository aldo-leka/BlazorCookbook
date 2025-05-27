using System.ComponentModel.DataAnnotations;

namespace Chapter_7_Validating_User_Input_Forms.Client.Recipe06;

public class Event
{
    [EventNameValidation]
    public string Name { get; set; }
    
    [ValidateComplexType]
    public EventLocation Location { get; set; } = new();
}
