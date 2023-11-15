namespace InnoGotchi.Core.Entities.DataTransferObject;

public record UserForUpdateDto(string FirstName, string LastName, byte[]? Avatar);
