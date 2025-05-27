using Microsoft.AspNetCore.Identity;

namespace Chapter_8_Keeping_the_Application_Secure.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}