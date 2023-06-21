namespace Pustok.Business.DTOs.AuthDtos;

public record TokenResponseDto(string Token, DateTime Expires, string UserName);