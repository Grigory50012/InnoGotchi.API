using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Models;
using InnoGotchi.Core.Services.Abstractions.UserServices;
using Microsoft.AspNetCore.Identity;

namespace InnoGotchi.Core.Services.UserServices;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public AuthenticationService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        var user = _mapper.Map<User>(userForRegistration);

        var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            
        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

        return result;
    }
}
