using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.Core.Entities.DataTransferObject;

public class FarmForCreationDto 
{
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Farm name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the farm name is 50 characters.")]
    public required string Name { get; set; }
} 
