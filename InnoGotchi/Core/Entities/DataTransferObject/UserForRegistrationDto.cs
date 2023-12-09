using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.Core.Entities.DataTransferObject;

public class UserForRegistrationDto
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string UserName { get => Email; }

    public required string Email { get; set; }

    public ICollection<string>? Roles { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
}
