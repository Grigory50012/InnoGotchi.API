namespace InnoGotchi.Core.Entities.Exceptions
{
    public sealed class PetNotFoundException : NotFoundException
    {
        public PetNotFoundException(Guid id)
            : base($"Pet with id: '{id}' not found")
        { }
    }
}
