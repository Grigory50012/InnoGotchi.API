using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.Core.Entities.DataTransferObject
{
    public record class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
