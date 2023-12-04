namespace InnoGotchi.Core.Entities.DataTransferObject;

public class UserPasswordForUpdateDto
{
    public Guid Id { get; set; }

    public required string OldPassword { get; set; }

    public required string NewPassword { get; set; }
}
