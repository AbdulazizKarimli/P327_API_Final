using Microsoft.AspNetCore.Mvc;
using Pustok.Business.DTOs.UserDtos;
using Pustok.Business.Services.Interfaces;

namespace Pustok.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(UserPostDto userPostDto)
    {
        var response = await _userService.CreateUserAsync(userPostDto);
        return StatusCode(response.StatusCode, response.Message);
    }
}