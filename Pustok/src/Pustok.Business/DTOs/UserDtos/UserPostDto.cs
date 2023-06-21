namespace Pustok.Business.DTOs.UserDtos;

public record UserPostDto(string? Fullname, string UserName, string Email, string Password, string PasswordConfirm);