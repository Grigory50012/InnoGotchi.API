namespace InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string name)
        : base($"User with name: '{name}' not found")
    { }
}
