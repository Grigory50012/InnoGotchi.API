using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.Core.Services.Abstractions.UserServices;

public interface IAuthenticationService
{
    Task RegisterUser(UserForRegistrationDto userForRegistration);

    Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
    
    Task<TokenDto> CreateToken(bool populateExp);
    
    Task<TokenDto> RefreshToken(TokenDto tokenDto);
}
