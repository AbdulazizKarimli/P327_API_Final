using Pustok.Business.DTOs.ProductDtos;
using Pustok.Business.Exceptions.ProductExceptions;

namespace Pustok.Business.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductGetResponseDto>> GetAllProductsAsync(string? search)
    {
        var products = await _productRepository.GetFiltered(p => !string.IsNullOrWhiteSpace(search) ? p.Name.Contains(search) : true, "Category").ToListAsync();
        List<ProductGetResponseDto> productDtos = null;
        try
        {
            productDtos = _mapper.Map<List<ProductGetResponseDto>>(products);
        }
        catch (Exception ex)
        {

            throw;
        }

        return productDtos;
    }

    public async Task<ProductGetResponseDto> GetProductByIdAsync(Guid Id)
    {
        var product = await _productRepository.GetSingleAsync(p => p.Id == Id);
        if (product is null)
            throw new ProductNotFoundException($"Product not found by id: {Id}");

        var productDto = _mapper.Map<ProductGetResponseDto>(product);

        return productDto;
    }

    public async Task<ResponseDto> CreateProductAsync(ProductPostDto productPostDto)
    {
        bool isExist = await _productRepository.IsExistAsync(p => p.Name == productPostDto.Name);
        if (isExist)
            throw new ProductAlreadyExistException($"Product already exist with name: {productPostDto.Name}");

        var newProduct = _mapper.Map<Product>(productPostDto);

        await _productRepository.CreateAsync(newProduct);
        await _productRepository.SaveAsync();

        return new((int)HttpStatusCode.Created, "Product successfully created");
    }

    public async Task<ResponseDto> UpdateProductAsync(ProductPutDto productPutDto)
    {
        bool isExist = await _productRepository.IsExistAsync(p => p.Name == productPutDto.Name && p.Id != productPutDto.Id);
        if (isExist)
            throw new ProductAlreadyExistException($"Product already exist with name: {productPutDto.Name}");

        var product = await _productRepository.GetSingleAsync(p => p.Id == productPutDto.Id);
        if (product is null)
            throw new ProductNotFoundException($"Product not found by id: {productPutDto.Id}");

        var updatedProduct = _mapper.Map(productPutDto, product);

        _productRepository.Update(updatedProduct);
        await _productRepository.SaveAsync();

        return new((int)HttpStatusCode.OK, "Product successfully updated");
    }

    public async Task<ResponseDto> DeleteProductAsync(Guid Id)
    {
        var product = await _productRepository.GetSingleAsync(p => p.Id == Id);
        if (product is null)
            throw new ProductNotFoundException($"Product not found by id: {Id}");

        _productRepository.SoftDelete(product);
        await _productRepository.SaveAsync();

        return new((int)HttpStatusCode.OK, "Product successfully deleted");
    }
}