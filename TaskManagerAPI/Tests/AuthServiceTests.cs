using Moq;
using Microsoft.AspNetCore.Identity;
using TaskManagerAPI.Services;
using TaskManagerAPI.Models;
using TaskManagerAPI.DTOs;
using Xunit;

public class AuthServiceTests
{
    private readonly Mock<UserManager<User>> _userManagerMock;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        _userManagerMock = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
        _configurationMock = new Mock<IConfiguration>();
        _authService = new AuthService(_userManagerMock.Object, _configurationMock.Object);
    }

    [Fact]
    public async Task Register_ShouldCreateUser()
    {
        // Arrange
        var userDTO = new UserDTO { Username = "test", Password = "password" };
        _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<User>(), userDTO.Password)).ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _authService.Register(userDTO);

        // Assert
        Assert.True(result.Succeeded);
    }
}
