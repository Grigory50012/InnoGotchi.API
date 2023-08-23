namespace InnoGotchi.API.Core.Entities.Models;

public class Collaboration
{
    public Guid FarmId { get; set; }
    public Farm Farm { get; set; }
}
