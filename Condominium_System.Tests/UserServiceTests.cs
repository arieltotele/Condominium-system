using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Condominium_System.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IRepositoryWithId<User>> _mockUserRepo;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockUserRepo = new Mock<IRepositoryWithId<User>>();
            _userService = new UserService(_mockUserRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, FirstName = "Ramon", LastName = "Mella", Username="rmella"},
                new User { Id = 2, FirstName = "Juan", LastName = "Perez", Username="jperez"}
            };
            _mockUserRepo.Setup(r => r.GetAllWithIncludesAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, object>>[]>()))
                         .ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsUser()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "Ramon", LastName = "Mella", Username = "rmella" };
            _mockUserRepo.Setup(r => r.GetByIdWithIncludesAsync(1, It.IsAny<System.Linq.Expressions.Expression<Func<User, object>>[]>()))
                         .ReturnsAsync(user);

            // Act
            var result = await _userService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("rmella", result.Username);
        }

        [Fact]
        public async Task SearchUsersAsync_ById_ReturnsUser()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "Ramon", LastName = "Mella", Username = "rmella" };
            _mockUserRepo.Setup(r => r.GetByIdWithIncludesAsync(1, It.IsAny<System.Linq.Expressions.Expression<Func<User, object>>[]>()))
                         .ReturnsAsync(user);
            _mockUserRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
                         .ReturnsAsync(new List<User>()); // no other matches

            // Act
            var result = await _userService.SearchUsersAsync("1");

            // Assert
            Assert.Single(result);
            Assert.Equal("rmella", result.First().Username);
        }

        [Fact]
        public async Task SearchUsersAsync_ByCriteria_ReturnsUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, FirstName = "Ramon", LastName = "Mella", Username="rmella" },
                new User { Id = 2, FirstName = "Ana", LastName = "Gomez", Username="agomez" }
            };
            _mockUserRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
                         .ReturnsAsync(users);

            // Act
            var result = await _userService.SearchUsersAsync("A");

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CreateAsync_AddsUser()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "Ramon", LastName = "Mella", Username = "rmella" };
            _mockUserRepo.Setup(r => r.AddAsync(user)).Returns(Task.CompletedTask);
            _mockUserRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            // Act
            var created = await _userService.CreateAsync(user);

            // Assert
            _mockUserRepo.Verify(r => r.AddAsync(user), Times.Once);
            _mockUserRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.Equal(user, created);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesUser()
        {
            // Arrange
            var user = new User { Id = 1, Username = "rmella" };
            _mockUserRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            // Act
            await _userService.UpdateAsync(user);

            // Assert
            _mockUserRepo.Verify(r => r.Update(user), Times.Once);
            _mockUserRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_RemovesUserIfExists()
        {
            // Arrange
            var user = new User { Id = 1, Username = "rmella" };
            _mockUserRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);
            _mockUserRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            // Act
            await _userService.DeleteAsync(1);

            // Assert
            _mockUserRepo.Verify(r => r.Remove(user), Times.Once);
            _mockUserRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UsernameExistsAsync_ReturnsTrueIfExists()
        {
            // Arrange
            var users = new List<User> { new User { Id = 1, Username = "rmella", IsActive = true } };
            _mockUserRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
                         .ReturnsAsync(users);

            // Act
            var exists = await _userService.UsernameExistsAsync("rmella");

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public async Task UsernameExistsAsync_ReturnsFalseIfNotExists()
        {
            // Arrange
            _mockUserRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
                         .ReturnsAsync(new List<User>());

            // Act
            var exists = await _userService.UsernameExistsAsync("notfound");

            // Assert
            Assert.False(exists);
        }
    }
}
