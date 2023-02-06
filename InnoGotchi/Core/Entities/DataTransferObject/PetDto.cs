namespace InnoGotchi.Core.Entities.DataTransferObject
{
    public class PetDto
    {
        public Guid PetId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public int DaysOfHappiness { get; set; }

        public DateTime FeedingDate { get; set; }

        public DateTime DrinkingDate { get; set; }

        public List<BodyPartDto> BodyParts { get; set; } = new();

        public bool IsDead() 
        {
            if (DateOfDeath is not null)
                return true;
            return false;
        }

        public int Age()
        {
            if (DateOfDeath is not null)
                return (DateOfDeath - DateOfBirth).Value.Days / 7;
            return (DateTime.Now - DateOfBirth).Days / 7;
        }
    }
}
