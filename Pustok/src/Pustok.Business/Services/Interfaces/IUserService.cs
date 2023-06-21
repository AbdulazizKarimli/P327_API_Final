using Pustok.Business.DTOs.UserDtos;

namespace Pustok.Business.Services.Interfaces;

public interface IUserService
{
    Task<ResponseDto> CreateUserAsync(UserPostDto userPostDto);
}