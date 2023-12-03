namespace InnoGotchi.Core.Entities.Exceptions.BadRequestException;

public sealed class PatchDocObjectIsNullBadRequestException : BadRequestException
{
    public PatchDocObjectIsNullBadRequestException()
        : base("PatchDoc object sent from client is null.") { }
}
