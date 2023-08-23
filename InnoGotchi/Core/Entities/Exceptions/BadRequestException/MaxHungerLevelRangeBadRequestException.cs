namespace InnoGotchi.Core.Entities.Exceptions.BadRequestException;

public sealed class MaxHungerLevelRangeBadRequestException : BadRequestException
{
    public MaxHungerLevelRangeBadRequestException()
        : base("Max HungerLevel can't be less than min HungerLevel.")
    {
    }
}
