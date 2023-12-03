using InnoGotchi.Core.Entities.Models;

namespace InnoGotchi.API.Core.Entities.Models;

public class Collaboration
{
    public Guid FarmId { get; set; }

    public Guid UserId { get; set; }

    public required Farm Farm { get; set; }

    public required User User { get; set; }
}
