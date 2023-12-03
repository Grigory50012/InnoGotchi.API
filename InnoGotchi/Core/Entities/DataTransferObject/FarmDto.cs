namespace InnoGotchi.Core.Entities.DataTransferObject;

public class FarmDto
{
    public Guid FarmId { get; set; }

    public Guid UserId { get; set; }

    public required string Name { get; set; }

    public List<PetDto>? Pets { get; set; } = new();
}
