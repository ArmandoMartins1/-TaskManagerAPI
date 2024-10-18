public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO);
    Task DeleteCategory(int id);
    Task UpdateCategory(int id, CategoryDTO categoryDTO);
}
