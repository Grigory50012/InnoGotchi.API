namespace InnoGotchi.Core.Entities.Exceptions.BadRequestException;

public sealed class MaxThirstyLevelRangeBadRequestException : BadRequestException
{
    public MaxThirstyLevelRangeBadRequestException()
        : base("Max ThirstyLevel can't be less than min ThirstyLevel.")
    {
    }
}
