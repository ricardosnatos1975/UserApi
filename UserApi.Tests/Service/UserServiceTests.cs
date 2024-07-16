using Moq;
using UserApi.Data;
using UserApi.Models;
using UserApi.Services;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserApi.Interfaces;

public class UserServiceTests
{
    private readonly UserService _service;
    private readonly Mock<IUserRepository> _repositoryMock;

    public UserServiceTests()
    {
        _repositoryMock = new Mock<IUserRepository>();
        _service = new UserService(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAllUsersAsync_ShouldReturnAllUsers()
    {
        // Arrange
        var users = new List<User> { new User { Id = 1, Name = "Test", Email = "test@test.com", Password = "password" } };
        _repositoryMock.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(users);

        // Act
        var result = await _service.GetAllUsersAsync();

        // Assert
        Assert.Equal(users, result);
    }

    [Fact]
    public async Task GetUserByIdAsync_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Test", Email = "test@test.com", Password = "password" };
        _repositoryMock.Setup(repo => repo.GetUserByIdAsync(1)).ReturnsAsync(user);

        // Act
        var result = await _service.GetUserByIdAsync(1);

        // Assert
        Assert.Equal(user, result);
    }

    [Fact]
    public async Task GetUserByIdAsync_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Arrange
        _repositoryMock.Setup(repo => repo.GetUserByIdAsync(1)).ReturnsAsync((User)null);

        // Act
        var result = await _service.GetUserByIdAsync(1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task AddUserAsync_ShouldAddUser()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Test", Email = "test@test.com", Password = "password" };

        // Act
        await _service.AddUserAsync(user);

        // Assert
        _repositoryMock.Verify(repo => repo.AddUserAsync(user), Times.Once);
    }

    [Fact]
    public async Task UpdateUserAsync_ShouldUpdateUser()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Test", Email = "test@test.com", Password = "password" };

        // Act
        await _service.UpdateUserAsync(user);

        // Assert
        _repositoryMock.Verify(repo => repo.UpdateUserAsync(user), Times.Once);
    }

    [Fact]
    public async Task DeleteUserAsync_ShouldDeleteUser()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Test", Email = "test@test.com", Password = "password" };
        _repositoryMock.Setup(repo => repo.GetUserByIdAsync(1)).ReturnsAsync(user);

        // Act
        await _service.DeleteUserAsync(1);

        // Assert
        _repositoryMock.Verify(repo => repo.DeleteUserAsync(1), Times.Once);
    }
}