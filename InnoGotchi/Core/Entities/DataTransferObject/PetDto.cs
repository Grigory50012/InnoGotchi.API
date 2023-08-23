using InnoGotchi.API.Core.Entities.Models.Enums;

namespace InnoGotchi.Core.Entities.DataTransferObject;

public class PetDto
{
    public Guid PetId { get; set; }

    public string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime DateOfDeath { get; set; }

    public DateTime DaysOfHappiness { get; set; }

    public DateTime FeedingDate { get; set; }

    public DateTime DrinkingDate { get; set; }

    public bool IsDead => DateOfDeath < DateTime.Now;

    public int Age => 
        IsDead ? (DateOfDeath - DateOfBirth).Days / 7 : (DateTime.Now - DateOfBirth).Days / 7;

    public HungerLevel HungerLevel
    {
        get
        {
            if (FeedingDate.AddDays(7) < DateTime.Now)
                return HungerLevel.Dead;
            if (FeedingDate.AddDays(5) < DateTime.Now)
                return HungerLevel.Hungry;
            if (FeedingDate.AddDays(3) < DateTime.Now)
                return HungerLevel.Normal;
            else
                return HungerLevel.Full;
        }
    }

    public ThirstyLevel ThirstyLevel
    {
        get
        {
            if (DrinkingDate.AddDays(7) < DateTime.Now)
                return ThirstyLevel.Dead;
            if (DrinkingDate.AddDays(5) < DateTime.Now)
                return ThirstyLevel.Thirsty;
            if (DrinkingDate.AddDays(3) < DateTime.Now)
                return ThirstyLevel.Normal;
            else
                return ThirstyLevel.Full;
        }
    }

    public int NumberOfHappyDays => 
        IsDead ? 0 : (DateTime.Now - DaysOfHappiness).Days;

    public List<BodyPartDto> BodyParts { get; set; } = new();
}
