namespace InnoGotchi.API.Core.Entities.Models;

public class BodyPart
{
     public Guid BodyPartId { get; set; }

     public required string Name { get; set; }

     public required string ImageUrl { get; set; }

     public List<Pet> Pets { get; set; } = new();
}
