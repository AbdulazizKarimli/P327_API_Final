using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok.Business.DTOs.ProductDtos;
using Pustok.Business.Services.Interfaces;

namespace Pustok.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll([FromQuery] string? search)
    {
        return Ok(await _productService.GetAllProductsAsync(search));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(await _productService.GetProductByIdAsync(id));
    }

    [HttpPost("")]
    public async Task<IActionResult> Post([FromBody] ProductPostDto productPostDto)
    {
        var response = await _productService.CreateProductAsync(productPostDto);
        return StatusCode(response.StatusCode, response.Message);
    }
}