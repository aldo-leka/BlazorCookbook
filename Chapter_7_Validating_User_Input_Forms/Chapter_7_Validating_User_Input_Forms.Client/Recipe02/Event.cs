using System.ComponentModel.DataAnnotations;

namespace Chapter_7_Validating_User_Input_Forms.Client.Recipe02;

public class Event
{
    [Required(ErrorMessage = "You must provide a name.")]
    public string Name { get; set; }
}
