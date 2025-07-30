using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Condominium_System.Tests.Services
{
    public class HousingEntityServiceTests
    {
        private readonly Mock<IRepositoryWithId<Housing>> _mockRepo;
        private readonly HousingEntityService _service;

        public HousingEntityServiceTests()
        {
            _mockRepo = new Mock<IRepositoryWithId<Housing>>();
            _service = new HousingEntityService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllHousingsAsync_ShouldReturnAllWithIncludes()
        {
            // Arrange
            var testData = new List<Housing>
            {
                new Housing { 
                    Id = 1, 
                    Code = "A101",
                    BlockId = 1,
                    Block = new Block { Id = 1, Name = "Block A" },
                    Services = new List<HousingService>(),
                    Furnitures = new List<HousingFurniture>(),
                    Tenants = new List<Tenant>()
                },
                new Housing { 
                    Id = 2, 
                    Code = "A102",
                    BlockId = 1,
                    Block = new Block { Id = 1, Name = "Block A" },
                    Services = new List<HousingService>(),
                    Furnitures = new List<HousingFurniture>(),
                    Tenants = new List<Tenant>()
                }
            };

            _mockRepo.Setup(x => x.GetAllWithIncludesAsync(
                    It.IsAny<Expression<Func<Housing, object>>>(),
                    It.IsAny<Expression<Func<Housing, object>>>(),
                    It.IsAny<Expression<Func<Housing, object>>>(),
                    It.IsAny<Expression<Func<Housing, object>>>()))
                .ReturnsAsync(testData);

            // Act
            var result = await _service.GetAllHousingsAsync();

            // Assert
            Assert.Equal(2, result.Count());
            _mockRepo.Verify(x => x.GetAllWithIncludesAsync(
                h => h.Block,
                h => h.Services,
                h => h.Furnitures,
                h => h.Tenants), Times.Once);
        }

        [Fact]
        public async Task GetHousingByIdAsync_ShouldReturnWithIncludes()
        {
            // Arrange
            var testHousing = new Housing 
            { 
                Id = 1,
                Code = "B201",
                PeopleCount = 4,
                RoomCount = 3,
                BathroomCount = 2,
                BlockId = 2,
                Block = new Block { Id = 2, Name = "Block B" },
                Services = new List<HousingService>(),
                Furnitures = new List<HousingFurniture>(),
                Tenants = new List<Tenant>()
            };

            _mockRepo.Setup(x => x.GetByIdWithIncludesAsync(
                    1, 
                    It.IsAny<Expression<Func<Housing, object>>>(),
                    It.IsAny<Expression<Func<Housing, object>>>(),
                    It.IsAny<Expression<Func<Housing, object>>>(),
                    It.IsAny<Expression<Func<Housing, object>>>()))
                .ReturnsAsync(testHousing);

            // Act
            var result = await _service.GetHousingByIdAsync(1);

            // Assert
            Assert.Equal("B201", result.Code);
            Assert.Equal(2, result.BlockId);
            Assert.NotNull(result.Block);
            _mockRepo.Verify(x => x.GetByIdWithIncludesAsync(
                1, 
                h => h.Block,
                h => h.Services,
                h => h.Furnitures,
                h => h.Tenants), Times.Once);
        }

        [Fact]
        public async Task CreateHousingAsync_ShouldAddWithRequiredProperties()
        {
            // Arrange
            var newHousing = new Housing
            {
                Code = "C301",
                PeopleCount = 2,
                RoomCount = 1,
                BathroomCount = 1,
                BlockId = 3,
                IsActive = true,
                Author = "admin",
                CreatedAt = DateTime.Now
            };

            _mockRepo.Setup(x => x.AddAsync(It.IsAny<Housing>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateHousingAsync(newHousing);

            // Assert
            _mockRepo.Verify(x => x.AddAsync(It.Is<Housing>(h => 
                h.Code == "C301" && 
                h.BlockId == 3 &&
                h.IsActive == true)), Times.Once);
            
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateHousingAsync_ShouldThrowIfMissingRequiredProperties()
        {
            // Arrange
            var invalidHousing = new Housing
            {
                // Falta Code (requerido)
                BlockId = 1
            };

            _mockRepo.Setup(x => x.AddAsync(invalidHousing))
                .ThrowsAsync(new DbUpdateException("Simulated validation error"));

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => _service.CreateHousingAsync(invalidHousing));
        }

        [Fact]
        public async Task UpdateHousingAsync_ShouldUpdateExisting()
        {
            // Arrange
            var existingHousing = new Housing
            {
                Id = 1,
                Code = "OldCode",
                PeopleCount = 2
            };

            var updatedHousing = new Housing
            {
                Id = 1,
                Code = "NewCode",
                PeopleCount = 3,
                UpdatedAt = DateTime.Now
            };

            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(existingHousing);

            // Act
            await _service.UpdateHousingAsync(updatedHousing);

            // Assert
            _mockRepo.Verify(x => x.Update(It.Is<Housing>(h => 
                h.Code == "NewCode" &&
                h.PeopleCount == 3 &&
                h.UpdatedAt != null)), Times.Once);
            
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteHousingAsync_ShouldSoftDelete()
        {
            // Arrange
            var housingToDelete = new Housing
            {
                Id = 1,
                Code = "D401",
                IsActive = true
            };

            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(housingToDelete);

            // Configurar el mock para reflejar el comportamiento real de Remove
            _mockRepo.Setup(x => x.Remove(It.IsAny<Housing>()))
                .Callback<Housing>(h => 
                {
                    h.IsActive = false;
                    h.DeletedAt = DateTime.Now;
                });

            // Act
            await _service.DeleteHousingAsync(1);

            // Assert
            _mockRepo.Verify(x => x.Remove(housingToDelete), Times.Once);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
            
            // Verificar soft delete
            Assert.False(housingToDelete.IsActive);
            Assert.NotNull(housingToDelete.DeletedAt);
        }

        [Fact]
        public async Task DeleteHousingAsync_ShouldDoNothingIfNotFound()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Housing)null);

            // Act
            await _service.DeleteHousingAsync(1);

            // Assert
            _mockRepo.Verify(x => x.Remove(It.IsAny<Housing>()), Times.Never);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Never);
        }

        [Theory]
        [InlineData(1, 1, 1, "A101")]
        [InlineData(2, 3, 2, "B202")]
        public async Task CreateHousingAsync_ShouldHandleDifferentValues(int people, int rooms, int bathrooms, string code)
        {
            // Arrange
            var newHousing = new Housing
            {
                Code = code,
                PeopleCount = people,
                RoomCount = rooms,
                BathroomCount = bathrooms,
                BlockId = 1
            };

            _mockRepo.Setup(x => x.AddAsync(It.IsAny<Housing>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateHousingAsync(newHousing);

            // Assert
            Assert.Equal(code, result.Code);
            Assert.Equal(people, result.PeopleCount);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}