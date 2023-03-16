using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.Core.Entities.DataTransferObject
{
    
    public class FarmForCreationDto 
    {
        [Required(ErrorMessage = "Farm name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the farm name is 50 characters.")]
        public string Name { get; set; }

        public Guid OwnerId { get; set; }
    } 
}
