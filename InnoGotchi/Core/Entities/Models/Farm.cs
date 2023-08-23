namespace InnoGotchi.API.Core.Entities.Models;

public class Farm
{
    public Guid FarmId { get; set; }
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public List<Pet>? Pets { get; set; }
    public List<Collaboration>? Collaborations { get; set; }
}
