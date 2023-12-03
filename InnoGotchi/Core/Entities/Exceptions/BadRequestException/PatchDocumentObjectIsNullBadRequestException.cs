namespace InnoGotchi.Core.Entities.Exceptions.BadRequestException;

public sealed class PatchDocumentObjectIsNullBadRequestException : Exception
{
    public PatchDocumentObjectIsNullBadRequestException()
        : base("PatchDoc object sent is null.") { }
}
