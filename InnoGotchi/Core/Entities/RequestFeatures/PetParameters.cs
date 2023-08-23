﻿using InnoGotchi.API.Core.Entities.Models.Enums;

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

    public DateTime MinFeedingDate
    {
        get
        {
            if (MinHungerLevel is HungerLevel.Dead)
                return DateTime.MinValue;
            if (MinHungerLevel is HungerLevel.Hungry)
                return DateTime.Now.AddDays(-5);
            if (MinHungerLevel is HungerLevel.Normal)
                return DateTime.Now.AddDays(-3);
            else 
                return DateTime.Now;
        }
    }

    public DateTime MaxFeedingDate
    {
        get
        {
            if (MaxHungerLevel is HungerLevel.Dead)
                return DateTime.MinValue;
            if (MaxHungerLevel is HungerLevel.Hungry)
                return DateTime.Now.AddDays(-7);
            if (MaxHungerLevel is HungerLevel.Normal)
                return DateTime.Now.AddDays(-5);
            else
                return DateTime.Now.AddDays(-3);
        }
    }

    public ThirstyLevel MinThirstyLevel { get; set; } = ThirstyLevel.Full;
    public ThirstyLevel MaxThirstyLevel { get; set; } = ThirstyLevel.Dead;

    public DateTime MinDrinkingDate
    {
        get
        {
            if (MinThirstyLevel is ThirstyLevel.Dead)
                return DateTime.MinValue;
            if (MinThirstyLevel is ThirstyLevel.Thirsty)
                return DateTime.Now.AddDays(-5);
            if (MinThirstyLevel is ThirstyLevel.Normal)
                return DateTime.Now.AddDays(-3);
            else
                return DateTime.Now;
        }
    }

    public DateTime MaxDrinkingDate
    {
        get
        {
            if (MaxThirstyLevel is ThirstyLevel.Dead)
                return DateTime.MinValue;
            if (MaxThirstyLevel is ThirstyLevel.Thirsty)
                return DateTime.Now.AddDays(-7);
            if (MaxThirstyLevel is ThirstyLevel.Normal)
                return DateTime.Now.AddDays(-5);
            else
                return DateTime.Now.AddDays(-3);
        }
    }

    public bool ValidAgeRange => MaxAge >= MinAge;

    public bool ValidHungerLevelRange => (int)MaxHungerLevel >= (int)MinHungerLevel;

    public bool ValidThirstyLevelRange => (int)MaxThirstyLevel >= (int)MinThirstyLevel;

    public PetParameters() => OrderBy = "daysOfHappiness";
}