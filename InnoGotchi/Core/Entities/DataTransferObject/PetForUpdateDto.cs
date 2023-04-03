namespace InnoGotchi.Core.Entities.DataTransferObject
{
    public class PetForUpdateDto
    {
        public DateTime FeedingDate { get; set; }

        public DateTime DrinkingDate { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public DateTime DaysOfHappiness { get; set; }
    }
}
