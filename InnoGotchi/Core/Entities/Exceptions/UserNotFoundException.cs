namespace InnoGotchi.Core.Entities.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string email)
            : base($"User with email: '{email}' not found") 
        { }
    }
}
