namespace InnoGotchi.Core.Entities.DataTransferObject
{
    public class FarmDto
    {
        public Guid FarmId { get; set; }

        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        public List<PetDto>? Pets { get; set; } = new();
    }
}
