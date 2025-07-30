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
    public class CondominiumServiceTests
    {
        private readonly Mock<IRepositoryWithId<Condominium>> _mockRepo;
        private readonly CondominiumService _service;

        public CondominiumServiceTests()
        {
            _mockRepo = new Mock<IRepositoryWithId<Condominium>>();
            _service = new CondominiumService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllCondominiumsAsync_ShouldReturnAllWithIncludes()
        {
            // Arrange
            var testData = new List<Condominium>
            {
                new Condominium { Id = 1, Name = "Condominio A" },
                new Condominium { Id = 2, Name = "Condominio B" }
            };

            _mockRepo.Setup(x => x.GetAllWithIncludesAsync(
                    It.IsAny<Expression<Func<Condominium, object>>>(),
                    It.IsAny<Expression<Func<Condominium, object>>>()))
                .ReturnsAsync(testData);

            // Act
            var result = await _service.GetAllCondominiumsAsync();

            // Assert
            Assert.Equal(2, result.Count());
            _mockRepo.Verify(x => x.GetAllWithIncludesAsync(
                c => c.Users,
                c => c.Blocks), Times.Once);
        }

        [Fact]
        public async Task GetCondominiumByIdAsync_ShouldReturnWithIncludes()
        {
            // Arrange
            var testCondominium = new Condominium 
            { 
                Id = 1, 
                Name = "Condominio Ejemplo",
                Address = "Calle Principal 123",
                ReceptionContactNumber = "+1234567890"
            };

            _mockRepo.Setup(x => x.GetByIdWithIncludesAsync(
                    1, 
                    It.IsAny<Expression<Func<Condominium, object>>>(),
                    It.IsAny<Expression<Func<Condominium, object>>>()))
                .ReturnsAsync(testCondominium);

            // Act
            var result = await _service.GetCondominiumByIdAsync(1);

            // Assert
            Assert.Equal("Condominio Ejemplo", result.Name);
            _mockRepo.Verify(x => x.GetByIdWithIncludesAsync(
                1, 
                c => c.Users,
                c => c.Blocks), Times.Once);
        }

        [Fact]
        public async Task CreateCondominiumAsync_ShouldAddWithRequiredProperties()
        {
            // Arrange
            var newCondominium = new Condominium
            {
                Name = "Nuevo Condominio",
                Address = "Av. Siempre Viva 742",
                ReceptionContactNumber = "+1234567890",
                BlockCount = 2,
                IsActive = true,
                Author = "admin",
                CreatedAt = DateTime.Now
            };

            _mockRepo.Setup(x => x.AddAsync(It.IsAny<Condominium>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateCondominiumAsync(newCondominium);

            // Assert
            _mockRepo.Verify(x => x.AddAsync(It.Is<Condominium>(c => 
                c.Name == "Nuevo Condominio" && 
                c.Address != null &&
                c.IsActive == true)), Times.Once);
            
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateCondominiumAsync_ShouldThrowIfMissingRequiredProperties()
        {
            // Arrange
            var invalidCondominium = new Condominium
            {
                // Falta Name (requerido)
                Address = "Dirección sin nombre"
            };

            _mockRepo.Setup(x => x.AddAsync(invalidCondominium))
                .ThrowsAsync(new DbUpdateException("Simulated validation error"));

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => _service.CreateCondominiumAsync(invalidCondominium));
        }

        [Fact]
        public async Task UpdateCondominiumAsync_ShouldUpdateExisting()
        {
            // Arrange
            var existingCondominium = new Condominium
            {
                Id = 1,
                Name = "Nombre Antiguo",
                ReceptionContactNumber = "111111111"
            };

            var updatedCondominium = new Condominium
            {
                Id = 1,
                Name = "Nombre Actualizado",
                ReceptionContactNumber = "222222222",
                UpdatedAt = DateTime.Now
            };

            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(existingCondominium);

            // Act
            await _service.UpdateCondominiumAsync(updatedCondominium);

            // Assert
            _mockRepo.Verify(x => x.Update(It.Is<Condominium>(c => 
                c.Name == "Nombre Actualizado" &&
                c.ReceptionContactNumber == "222222222" &&
                c.UpdatedAt != null)), Times.Once);
            
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteCondominiumAsync_ShouldSoftDelete()
        {
            // Arrange
            var condominiumToDelete = new Condominium
            {
                Id = 1,
                Name = "Condominio a Eliminar",
                IsActive = true
            };

            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(condominiumToDelete);

            // Configurar el mock para capturar el objeto modificado
            Condominium captured = null;
            _mockRepo.Setup(x => x.Remove(It.IsAny<Condominium>()))
                .Callback<Condominium>(c => 
                {
                    // Simulamos exactamente lo que hace tu repositorio
                    c.IsActive = false;
                    c.DeletedAt = DateTime.Now;
                    captured = c;
                });

            // Act
            await _service.DeleteCondominiumAsync(1);

            // Assert
            _mockRepo.Verify(x => x.Remove(condominiumToDelete), Times.Once);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
            
            // Verificamos que el objeto fue modificado correctamente
            Assert.False(condominiumToDelete.IsActive);
            Assert.NotNull(condominiumToDelete.DeletedAt);
            
            // Verificamos que el objeto capturado también está correcto
            if (captured != null)
            {
                Assert.False(captured.IsActive);
                Assert.NotNull(captured.DeletedAt);
            }
        }

        [Fact]
        public async Task DeleteCondominiumAsync_ShouldDoNothingIfNotFound()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Condominium)null);

            // Act
            await _service.DeleteCondominiumAsync(1);

            // Assert
            _mockRepo.Verify(x => x.Remove(It.IsAny<Condominium>()), Times.Never);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Never);
        }
    }
}