using InnoGotchi.API.Core.Entities.Models.Enums;

namespace InnoGotchi.Core.Entities.DataTransferObject;

public class PetDto
{
    public Guid PetId { get; set; }

    public required string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime DateOfDeath { get; set; }

    public DateTime DaysOfHappiness { get; set; }

    public DateTime FeedingDate { get; set; }

    public DateTime DrinkingDate { get; set; }

    public List<BodyPartDto> BodyParts { get; set; } = new();

    public bool IsDead => DateOfDeath < DateTime.Now;

    public int Age => 
        IsDead ? (DateOfDeath - DateOfBirth).Days / 7 : (DateTime.Now - DateOfBirth).Days / 7;

    public int NumberOfHappyDays =>
        IsDead ? 0 : (DateTime.Now - DaysOfHappiness).Days;

    public HungerLevel HungerLevel
    {
        get
        {
            int days = (DateTime.Now - FeedingDate).Days;

            switch (days)
            {
                case var _ when days >= 7:
                    return HungerLevel.Dead;
                case var _ when days >= 5:
                    return HungerLevel.Hungry;
                case var _ when days >= 3:
                    return HungerLevel.Normal;
                default:
                    return HungerLevel.Full;
            }
        }
    }

    public ThirstyLevel ThirstyLevel
    {
        get
        {
            int days = (DateTime.Now - DrinkingDate).Days;

            switch (days)
            {
                case var _ when days >= 7:
                    return ThirstyLevel.Dead;
                case var _ when days >= 5:
                    return ThirstyLevel.Thirsty;
                case var _ when days >= 3:
                    return ThirstyLevel.Normal;
                default:
                    return ThirstyLevel.Full;
            }
        }
    }
}
