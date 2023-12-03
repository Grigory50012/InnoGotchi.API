namespace InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption;

public sealed class UserNotFoundByEmailException : NotFoundException
{
    public UserNotFoundByEmailException(string email)
        : base($"User with email: '{email}' not found") { }
}
