using Microsoft.AspNetCore.Mvc;
using Pustok.Business.DTOs.AuthDtos;
using Pustok.Business.Services.Interfaces;

namespace Pustok.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        return Ok(await _authService.LoginAsync(loginDto));
    }
}