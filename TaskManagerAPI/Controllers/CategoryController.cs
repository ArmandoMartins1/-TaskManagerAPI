using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetCategories();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryDTO categoryDTO)
    {
        var category = await _categoryService.CreateCategory(categoryDTO);
        return CreatedAtAction(nameof(GetCategories), new { id = category }, category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategory(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDTO categoryDTO)
    {
        await _categoryService.UpdateCategory(id, categoryDTO);
        return NoContent();
    }
}
