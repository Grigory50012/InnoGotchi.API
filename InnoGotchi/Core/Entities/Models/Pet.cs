﻿namespace InnoGotchi.API.Core.Entities.Models;

public class Pet
{
    public Guid PetId { get; set; }

    public Guid FarmId { get; set; }

    public required string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime DateOfDeath { get; set; }

    public DateTime DaysOfHappiness { get; set; }

    public DateTime FeedingDate { get; set; }

    public DateTime DrinkingDate { get; set; }

    public required Farm Farm { get; set; }

    public List<BodyPart> BodyParts { get; set; } = new();
}
