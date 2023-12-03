using InnoGotchi.API.Core.Entities.Models.Enums;

namespace InnoGotchi.Core.Entities.RequestFeatures;

public class PetParameters : RequestParameters
{
    public uint MinAge { get; set; }

    public uint MaxAge { get; set; } = int.MaxValue;

    public DateTime MinDateOfBirth =>
        MinAge is 0 ? DateTime.Now : DateTime.Now.AddDays(-(MinAge * 7));

    public DateTime MaxDateOfBirth => 
        MaxAge is int.MaxValue ? DateTime.MinValue : DateTime.Now.AddDays(-((MaxAge * 7) + 6));

    public HungerLevel MinHungerLevel { get; set; } = HungerLevel.Full;

    public HungerLevel MaxHungerLevel { get; set; } = HungerLevel.Dead;

    public ThirstyLevel MinThirstyLevel { get; set; } = ThirstyLevel.Full;

    public ThirstyLevel MaxThirstyLevel { get; set; } = ThirstyLevel.Dead;

    public bool ValidAgeRange => MaxAge >= MinAge;

    public bool ValidHungerLevelRange => (int)MaxHungerLevel >= (int)MinHungerLevel;

    public bool ValidThirstyLevelRange => (int)MaxThirstyLevel >= (int)MinThirstyLevel;

    public PetParameters() => OrderBy = "daysOfHappiness";

    public DateTime MinFeedingDate
    {
        get
        {
            switch (MinHungerLevel)
            {
                case HungerLevel.Dead:
                    return DateTime.MinValue;
                case HungerLevel.Hungry:
                    return DateTime.Now.AddDays(-5);
                case HungerLevel.Normal: 
                    return DateTime.Now.AddDays(-3);
                default:
                    return DateTime.Now;
            }
        }
    }

    public DateTime MaxFeedingDate
    {
        get
        {
            switch (MaxHungerLevel)
            {
                case HungerLevel.Dead:
                    return DateTime.MinValue;
                case HungerLevel.Hungry:
                    return DateTime.Now.AddDays(-7);
                case HungerLevel.Normal:
                    return DateTime.Now.AddDays(-5);
                default:
                    return DateTime.Now.AddDays(-3);
            }
        }
    }

    public DateTime MinDrinkingDate
    {
        get
        {
            switch (MinThirstyLevel)
            {
                case ThirstyLevel.Dead:
                    return DateTime.MinValue;
                case ThirstyLevel.Thirsty:
                    return DateTime.Now.AddDays(-5);
                case ThirstyLevel.Normal:
                    return DateTime.Now.AddDays(-3);
                default:
                    return DateTime.Now;
            }
        }
    }

    public DateTime MaxDrinkingDate
    {
        get
        {
            switch (MinThirstyLevel)
            {
                case ThirstyLevel.Dead:
                    return DateTime.MinValue;
                case ThirstyLevel.Thirsty:
                    return DateTime.Now.AddDays(-7);
                case ThirstyLevel.Normal:
                    return DateTime.Now.AddDays(-5);
                default:
                    return DateTime.Now.AddDays(-3);
            }
        }
    }
}
