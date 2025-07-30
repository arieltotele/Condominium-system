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
    public class FurnitureServiceTests
    {
        private readonly Mock<IRepositoryWithId<Furniture>> _mockRepo;
        private readonly FurnitureService _service;

        public FurnitureServiceTests()
        {
            _mockRepo = new Mock<IRepositoryWithId<Furniture>>();
            _service = new FurnitureService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllFurnituresAsync_ShouldReturnAllWithHousings()
        {
            // Arrange
            var testData = new List<Furniture>
            {
                new Furniture { Id = 1, Name = "Sofá", Type = "Living" },
                new Furniture { Id = 2, Name = "Cama", Type = "Dormitorio" }
            };

            _mockRepo.Setup(x => x.GetAllWithIncludesAsync(It.IsAny<Expression<Func<Furniture, object>>>()))
                .ReturnsAsync(testData);

            // Act
            var result = await _service.GetAllFurnituresAsync();

            // Assert
            Assert.Equal(2, result.Count());
            _mockRepo.Verify(x => x.GetAllWithIncludesAsync(f => f.Housings), Times.Once);
        }

        [Fact]
        public async Task GetFurnitureByIdAsync_ShouldReturnWithHousings()
        {
            // Arrange
            var testFurniture = new Furniture 
            { 
                Id = 1, 
                Name = "Mesa de centro",
                Type = "Living",
                Detail = "Mesa de madera"
            };

            _mockRepo.Setup(x => x.GetByIdWithIncludesAsync(
                    1, 
                    It.IsAny<Expression<Func<Furniture, object>>>()))
                .ReturnsAsync(testFurniture);

            // Act
            var result = await _service.GetFurnitureByIdAsync(1);

            // Assert
            Assert.Equal("Mesa de centro", result.Name);
            _mockRepo.Verify(x => x.GetByIdWithIncludesAsync(1, f => f.Housings), Times.Once);
        }

        [Fact]
        public async Task GetFurnituresByTypeAsync_ShouldFilterCorrectly()
        {
            // Arrange
            var testData = new List<Furniture>
            {
                new Furniture { Id = 1, Name = "Sofá", Type = "Living", Housings = new List<HousingFurniture>() },
                new Furniture { Id = 2, Name = "Sillón", Type = "Living", Housings = new List<HousingFurniture>() },
                new Furniture { Id = 3, Name = "Cama", Type = "Dormitorio", Housings = new List<HousingFurniture>() }
            };

            // Mock para devolver todos los datos (el filtro se aplica después en el servicio)
            _mockRepo.Setup(x => x.GetAllWithIncludesAsync(It.IsAny<Expression<Func<Furniture, object>>>()))
                .ReturnsAsync(testData);

            // Act
            var result = await _service.GetFurnituresByTypeAsync("Living");

            // Assert - El servicio debe filtrar los resultados
            var filteredResult = result.ToList();
            Assert.Equal(2, filteredResult.Count);
            Assert.All(filteredResult, f => {
                Assert.Equal("Living", f.Type);
                Assert.NotNull(f.Housings); // Verifica que se cargó la relación
            });
        }

        [Fact]
        public async Task CreateFurnitureAsync_ShouldAddWithRequiredProperties()
        {
            // Arrange
            var newFurniture = new Furniture
            {
                Name = "Escritorio",
                Type = "Oficina",
                Detail = "Madera de roble",
                IsActive = true,
                Author = "admin",
                CreatedAt = DateTime.Now
            };

            _mockRepo.Setup(x => x.AddAsync(It.IsAny<Furniture>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateFurnitureAsync(newFurniture);

            // Assert
            _mockRepo.Verify(x => x.AddAsync(It.Is<Furniture>(f => 
                f.Name == "Escritorio" && 
                f.Type == "Oficina" &&
                f.IsActive == true)), Times.Once);
            
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateFurnitureAsync_ShouldThrowIfMissingRequiredProperties()
        {
            // Arrange
            var invalidFurniture = new Furniture
            {
                // Falta Name (requerido)
                Type = "Sin nombre"
            };

            _mockRepo.Setup(x => x.AddAsync(invalidFurniture))
                .ThrowsAsync(new DbUpdateException("Simulated validation error"));

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => _service.CreateFurnitureAsync(invalidFurniture));
        }

        [Fact]
        public async Task UpdateFurnitureAsync_ShouldUpdateExisting()
        {
            // Arrange
            var existingFurniture = new Furniture
            {
                Id = 1,
                Name = "Silla vieja",
                Type = "Comedor"
            };

            var updatedFurniture = new Furniture
            {
                Id = 1,
                Name = "Silla nueva",
                Type = "Comedor",
                Detail = "Con respaldo alto",
                UpdatedAt = DateTime.Now
            };

            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(existingFurniture);

            // Act
            await _service.UpdateFurnitureAsync(updatedFurniture);

            // Assert
            _mockRepo.Verify(x => x.Update(It.Is<Furniture>(f => 
                f.Name == "Silla nueva" &&
                f.Detail == "Con respaldo alto" &&
                f.UpdatedAt != null)), Times.Once);
            
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteFurnitureAsync_ShouldSoftDelete()
        {
            // Arrange
            var furnitureToDelete = new Furniture
            {
                Id = 1,
                Name = "Lámpara",
                Type = "Iluminación",
                IsActive = true
            };

            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(furnitureToDelete);

            // Configuramos el mock para reflejar el comportamiento real de Remove
            _mockRepo.Setup(x => x.Remove(It.IsAny<Furniture>()))
                .Callback<Furniture>(f => 
                {
                    f.IsActive = false;
                    f.DeletedAt = DateTime.Now;
                });

            // Act
            await _service.DeleteFurnitureAsync(1);

            // Assert
            _mockRepo.Verify(x => x.Remove(furnitureToDelete), Times.Once);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
            
            // Verificamos el soft delete
            Assert.False(furnitureToDelete.IsActive);
            Assert.NotNull(furnitureToDelete.DeletedAt);
        }

        [Fact]
        public async Task DeleteFurnitureAsync_ShouldDoNothingIfNotFound()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Furniture)null);

            // Act
            await _service.DeleteFurnitureAsync(1);

            // Assert
            _mockRepo.Verify(x => x.Remove(It.IsAny<Furniture>()), Times.Never);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Never);
        }
    }
}