

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categories = await _categoryRepository.GetAll();
        return categories.Select(c => new CategoryDTO { Name = c.Name });
    }

    public async Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
    {
        var category = new Category { Name = categoryDTO.Name };
        await _categoryRepository.Create(category);
        return categoryDTO;
    }

    public async Task DeleteCategory(int id)
    {
        await _categoryRepository.Delete(id);
    }

    public async Task UpdateCategory(int id, CategoryDTO categoryDTO)
    {
        var category = new Category { Id = id, Name = categoryDTO.Name };
        await _categoryRepository.Update(category);
    }
}
