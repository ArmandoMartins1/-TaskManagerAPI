using Moq;
using TaskManagerAPI.Services;

using Xunit;

public class CategoryServiceTests
{
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
    private readonly CategoryService _categoryService;

    public CategoryServiceTests()
    {
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
        _categoryService = new CategoryService(_categoryRepositoryMock.Object);
    }

    [Fact]
    public async Task GetCategories_ShouldReturnCategories()
    {
        // Arrange
        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Work" },
            new Category { Id = 2, Name = "Home" }
        };

        _categoryRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(categories);

        // Act
        var result = await _categoryService.GetCategories();

        // Assert
        Assert.Equal(2, result.Count());
    }
}
