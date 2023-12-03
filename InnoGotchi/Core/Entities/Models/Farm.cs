using InnoGotchi.Core.Entities.Models;

namespace InnoGotchi.API.Core.Entities.Models;

public class Farm
{
    public Guid FarmId { get; set; }

    public Guid UserId { get; set; }

    public required User User { get; set; }

    public required string Name { get; set; }

    public List<Pet>? Pets { get; set; }

    public List<Collaboration>? Collaborations { get; set; }
}
