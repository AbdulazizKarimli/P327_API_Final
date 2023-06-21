using Pustok.Business.DTOs.CategoryDtos;
using Pustok.Business.DTOs.Common;

namespace Pustok.Business.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryGetResponseDto>> GetAllCategoriesAsync();
    Task<ResponseDto> CreateCategoryAsync(CategoryPostDto categoryPostDto);
}