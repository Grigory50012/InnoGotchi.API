using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.Core.Entities.DataTransferObject
{
    public class PetForCreationDto
    {
        public string Name { get; set; }

        public Guid FarmId { get; set; }

        public List<BodyPart> BodyParts { get; set; } = new();

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public DateTime DaysOfHappiness { get; set; } = DateTime.Now;

        public DateTime FeedingDate { get; set; } = DateTime.Now;

        public DateTime DrinkingDate { get; set; } = DateTime.Now;
    }
}
