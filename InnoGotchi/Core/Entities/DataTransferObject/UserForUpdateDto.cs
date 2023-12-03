namespace InnoGotchi.Core.Entities.DataTransferObject;

public class UserForUpdateDto
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    
    public byte[]? Avatar { get; set;}
}
