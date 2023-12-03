namespace InnoGotchi.Core.Entities.DataTransferObject;

public record BodyPartDto
{
    public Guid BodyPartId { get; set; }

    public required string Name { get; set; }

    public required string ImageUrl { get; set; }
}
