namespace InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption;

public sealed class UserNotFoundByIdException : NotFoundException
{
    public UserNotFoundByIdException(Guid id)
        : base($"User with Id: '{id}' not found") { }
}
