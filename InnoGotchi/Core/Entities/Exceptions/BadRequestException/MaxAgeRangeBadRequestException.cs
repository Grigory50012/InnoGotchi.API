namespace InnoGotchi.Core.Entities.Exceptions.BadRequestException;

public sealed class MaxAgeRangeBadRequestException : BadRequestException
{
    public MaxAgeRangeBadRequestException()
        : base("Max age can't be less than min age.")
    {
    }
}
