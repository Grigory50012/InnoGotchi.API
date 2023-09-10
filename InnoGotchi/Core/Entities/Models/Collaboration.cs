using InnoGotchi.Core.Entities.Models;

namespace InnoGotchi.API.Core.Entities.Models;

public class Collaboration
{
    public Guid FarmId { get; set; }
    public Farm Farm { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
