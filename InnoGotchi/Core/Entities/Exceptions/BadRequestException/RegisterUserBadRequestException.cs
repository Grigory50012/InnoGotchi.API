namespace InnoGotchi.Core.Entities.Exceptions.BadRequestException;

public sealed class RegisterUserBadRequestException : BadRequestException
{
    public RegisterUserBadRequestException(string errorMessage)
        : base(errorMessage) { }
}
