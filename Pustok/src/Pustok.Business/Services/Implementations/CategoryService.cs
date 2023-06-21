using Pustok.Business.DTOs.CategoryDtos;
using Pustok.Business.Exceptions.CategoryExceptions;

namespace Pustok.Business.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public Task<List<CategoryGetResponseDto>> GetAllCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto> CreateCategoryAsync(CategoryPostDto categoryPostDto)
    {
        bool isExist = await _categoryRepository.IsExistAsync(c => c.Name.Trim().ToLower() == categoryPostDto.Name.Trim().ToLower());
        if(isExist)
            throw new CategoryAlreadyExistException($"Category already exist with name: {categoryPostDto.Name}");

        Category category = _mapper.Map<Category>(categoryPostDto);

        await _categoryRepository.CreateAsync(category);
        await _categoryRepository.SaveAsync();

        return new((int)HttpStatusCode.Created, "Category successfully created");
    }
}