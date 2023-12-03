using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.Core.Entities.DataTransferObject;

public  class UserForAuthenticationDto
{
    [Required(ErrorMessage = "Email is required")]
    public required string Email { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; init; }
}
