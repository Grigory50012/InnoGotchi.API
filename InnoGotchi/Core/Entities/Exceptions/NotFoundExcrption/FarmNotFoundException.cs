namespace InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption;

public sealed class FarmNotFoundException : NotFoundException
{
    public FarmNotFoundException(Guid id)
        : base($"Farm with id: '{id}' not found")
    { }
}
