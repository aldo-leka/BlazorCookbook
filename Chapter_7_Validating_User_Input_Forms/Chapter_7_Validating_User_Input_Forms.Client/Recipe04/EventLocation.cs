using System.ComponentModel.DataAnnotations;

namespace Chapter_7_Validating_User_Input_Forms.Client.Recipe04;

public class EventLocation
{
    [Required(ErrorMessage = "You must provide a venue.")]
    public string Venue { get; set; }
    
    [Required, Range(1, 1000,
         ErrorMessage =
             "Capacity must be between 1 and 1000.")]
    public int Capacity { get; set; }
}