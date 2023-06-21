using Pustok.Business.DTOs.CategoryDtos;

namespace Pustok.Business.DTOs.ProductDtos;

public record ProductGetResponseDto(Guid Id, string Name, decimal Price, CategoryGetResponseDto Category);