using Moq;
using TaskManagerAPI.Repositories;
using TaskManagerAPI.Models;
using Xunit;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _taskRepositoryMock;
    private readonly TaskService _taskService;

    public TaskServiceTests()
    {
        _taskRepositoryMock = new Mock<ITaskRepository>();
        _taskService = new TaskService(_taskRepositoryMock.Object);
    }

    [Fact]
    public async Task GetTasks_ShouldReturnTasks()
    {
        // Arrange
        var tasks = new List<Task>
        {
            new Task { Id = 1, Title = "Task 1", Status = TaskStatus.Pending },
            new Task { Id = 2, Title = "Task 2", Status = TaskStatus.InProgress }
        };

        _taskRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(tasks);

        // Act
        var result = await _taskService.GetTasks(new TaskFilterDTO());

        // Assert
        Assert.Equal(2, result.Count());
    }
}
