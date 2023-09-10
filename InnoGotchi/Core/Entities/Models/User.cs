using InnoGotchi.API.Core.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace InnoGotchi.Core.Entities.Models;

public class User : IdentityUser<Guid>
{
    public Guid Id { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[]? Avatar { get; set; }

    public Guid FarmId { get; set; }
    public Farm Farm { get; set; }

    public List<Collaboration>? Collaborations { get; set; }
}
