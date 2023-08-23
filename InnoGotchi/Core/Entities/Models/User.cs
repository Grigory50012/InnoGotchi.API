using Microsoft.AspNetCore.Identity;

namespace InnoGotchi.Core.Entities.Models;

public class User : IdentityUser
{
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[]? Avatar { get; set; }
}
