namespace InnoGotchi.Core.Entities.Exceptions.UnauthorizedException;

public sealed class UnauthorizedUserException : UnauthorizedException
{
    public UnauthorizedUserException()
        : base("The user is not authorized. Check your password.") { }
}
