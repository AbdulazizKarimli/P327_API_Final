using Microsoft.AspNetCore.Mvc;
using Pustok.Business.DTOs.CategoryDtos;
using Pustok.Business.Services.Interfaces;

namespace Pustok.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CategoryPostDto categoryPostDto)
    {
        var response = await _categoryService.CreateCategoryAsync(categoryPostDto);
        return StatusCode(response.StatusCode, response.Message);
    }
}