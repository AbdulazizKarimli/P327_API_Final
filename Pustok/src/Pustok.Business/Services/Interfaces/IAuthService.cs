using Pustok.Business.DTOs.AuthDtos;

namespace Pustok.Business.Services.Interfaces;

public interface IAuthService
{
    Task<TokenResponseDto> LoginAsync(LoginDto loginDto);
}