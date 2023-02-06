namespace InnoGotchi.API.Core.Entities.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public byte[]? Avatar { get; set; }

        public Farm? Farm { get; set; }

        public List<Collaboration> Collaborations { get; set; } = new();
    }
}
