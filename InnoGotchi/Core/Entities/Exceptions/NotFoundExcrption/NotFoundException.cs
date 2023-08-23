namespace InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message)
        : base(message)
    { }
}
