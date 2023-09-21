using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Identity;

namespace InnoGotchi.Core.Services.Abstractions.UserServices;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
    Task<TokenDto> CreateToken(bool populateExp);
    Task<TokenDto> RefreshToken(TokenDto tokenDto);
}
