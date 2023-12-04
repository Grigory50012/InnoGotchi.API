namespace InnoGotchi.Core.Entities.Exceptions.BadRequestException;

public sealed class ChangePasswordBadRequestException : BadRequestException
{
    public ChangePasswordBadRequestException(string errorMessage)
       : base(errorMessage) { }
}
