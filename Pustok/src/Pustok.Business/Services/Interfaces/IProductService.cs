using Pustok.Business.DTOs.ProductDtos;

namespace Pustok.Business.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductGetResponseDto>> GetAllProductsAsync(string? search);
    Task<ProductGetResponseDto> GetProductByIdAsync(Guid Id);
    Task<ResponseDto> CreateProductAsync(ProductPostDto productPostDto);
    Task<ResponseDto> UpdateProductAsync(ProductPutDto productPutDto);
    Task<ResponseDto> DeleteProductAsync(Guid Id);
}