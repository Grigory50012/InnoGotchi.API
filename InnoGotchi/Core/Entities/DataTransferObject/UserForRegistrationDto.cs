using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.Core.Entities.DataTransferObject;

public class UserForRegistrationDto
{
    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public ICollection<string>? Roles { get; init; }

    [Required(ErrorMessage = "Username is required")]
    public required string UserName { get; init; } = "UserName";

    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; init; }
}
