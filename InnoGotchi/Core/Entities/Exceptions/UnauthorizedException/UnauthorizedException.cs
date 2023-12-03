namespace InnoGotchi.Core.Entities.Exceptions.UnauthorizedException;

public abstract class UnauthorizedException : Exception
{
    protected UnauthorizedException(string message) : base(message) { }
}
