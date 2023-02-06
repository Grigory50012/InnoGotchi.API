namespace InnoGotchi.API.Core.Entities.Models
{
    public class Collaboration
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid FarmId { get; set; }
        public Farm Farm { get; set; } = null!;
    }
}
