using InnoGotchi.API.Core.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.Core.Entities.DataTransferObject
{
    public class PetForCreationDto
    {
        [Required(ErrorMessage = "Pet name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the pet name is 50 characters.")]
        public string Name { get; set; }

        public Guid FarmId { get; set; }

        [Required(ErrorMessage = "Body parts is a required field.")]
        public List<BodyPart> BodyParts { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public DateTime DaysOfHappiness { get; set; } = DateTime.Now;

        public DateTime FeedingDate { get; set; } = DateTime.Now;

        public DateTime DrinkingDate { get; set; } = DateTime.Now;
    }
}
