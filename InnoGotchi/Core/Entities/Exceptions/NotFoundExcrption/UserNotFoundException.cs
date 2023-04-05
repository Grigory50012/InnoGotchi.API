namespace InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string email)
            : base($"User with email: '{email}' not found")
        { }
    }
}
