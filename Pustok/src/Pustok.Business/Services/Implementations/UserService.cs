using Microsoft.AspNetCore.Identity;
using Pustok.Business.DTOs.UserDtos;
using Pustok.Business.Exceptions.UserExceptions;
using Pustok.Core.Entities.Identity;

namespace Pustok.Business.Services.Implementations;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ResponseDto> CreateUserAsync(UserPostDto userPostDto)
    {
        AppUser user = new AppUser
        {
            Fullname = userPostDto.Fullname,
            UserName = userPostDto.UserName,
            Email = userPostDto.Email,
        };

        var identityResult = await _userManager.CreateAsync(user, userPostDto.Password);
        if (!identityResult.Succeeded)
        {
            throw new UserCreateFailedException(string.Join(" ", identityResult.Errors.Select(e => e.Description)));
        }

        return new((int)HttpStatusCode.Created, "User successfully created");
    }
}