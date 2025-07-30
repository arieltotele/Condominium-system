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
    public class BlockServiceTests
    {
        private readonly Mock<IRepositoryWithId<Block>> _mockRepo;
        private readonly BlockService _service;

        public BlockServiceTests()
        {
            _mockRepo = new Mock<IRepositoryWithId<Block>>();
            _service = new BlockService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllBlocksAsync_ShouldReturnAllBlocksWithIncludes()
        {
            // Arrange
            var testBlocks = new List<Block>
            {
                new Block { Id = 1, Name = "Block A", CondominiumId = 1, Author = "testUser" },
                new Block { Id = 2, Name = "Block B", CondominiumId = 1, Author = "testUser"}
            };

            _mockRepo.Setup(x => x.GetAllWithIncludesAsync(
                    It.IsAny<Expression<Func<Block, object>>>(),
                    It.IsAny<Expression<Func<Block, object>>>()))
                .ReturnsAsync(testBlocks);

            // Act
            var result = await _service.GetAllBlocksAsync();

            // Assert
            Assert.Equal(2, result.Count());
            _mockRepo.Verify(x => x.GetAllWithIncludesAsync(
                b => b.Condominium, 
                b => b.Housings), Times.Once);
        }

        [Fact]
        public async Task GetBlockByIdAsync_ShouldReturnBlockWithIncludes()
        {
            // Arrange
            var testBlock = new Block 
            { 
                Id = 1, 
                Name = "Block A",
                CondominiumId = 1,
                HousingType = "Apartment",
                HousingCount = 10,
                Address = "123 Main St"
            };

            _mockRepo.Setup(x => x.GetByIdWithIncludesAsync(
                    1, 
                    It.IsAny<Expression<Func<Block, object>>>(),
                    It.IsAny<Expression<Func<Block, object>>>()))
                .ReturnsAsync(testBlock);

            // Act
            var result = await _service.GetBlockByIdAsync(1);

            // Assert
            Assert.Equal("Block A", result.Name);
            Assert.Equal(1, result.CondominiumId);
            _mockRepo.Verify(x => x.GetByIdWithIncludesAsync(
                1, 
                b => b.Condominium, 
                b => b.Housings), Times.Once);
        }

        [Fact]
        public async Task CreateBlockAsync_ShouldAddBlockWithRequiredProperties()
        {
            // Arrange
            var newBlock = new Block
            {
                Name = "New Block",
                CondominiumId = 1,
                HousingType = "Apartment",
                HousingCount = 5,
                Address = "456 Oak St",
                Feature = "Pool",
                IsActive = true,
                Author = "testuser",
                CreatedAt = DateTime.Now
            };

            _mockRepo.Setup(x => x.AddAsync(It.IsAny<Block>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateBlockAsync(newBlock);

            // Assert
            _mockRepo.Verify(x => x.AddAsync(It.Is<Block>(b => 
                b.Name == "New Block" && 
                b.CondominiumId == 1 &&
                b.HousingType == "Apartment" &&
                b.IsActive == true)), Times.Once);
            
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
            Assert.Equal("New Block", result.Name);
        }

        [Fact]
        public async Task CreateBlockAsync_ShouldThrowIfMissingRequiredProperties()
        {
            // Arrange
            var invalidBlock = new Block
            {
                // Falta Name y CondominiumId (requeridos)
                HousingType = "Apartment"
            };

            _mockRepo.Setup(x => x.AddAsync(invalidBlock))
                .ThrowsAsync(new DbUpdateException("Simulated validation error"));

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => _service.CreateBlockAsync(invalidBlock));
        }

        [Fact]
        public async Task UpdateBlockAsync_ShouldUpdateExistingBlock()
        {
            // Arrange
            var existingBlock = new Block
            {
                Id = 1,
                Name = "Old Name",
                CondominiumId = 1,
                HousingType = "Apartment",
                HousingCount = 10,
                Address = "123 Main St"
            };

            var updatedBlock = new Block
            {
                Id = 1,
                Name = "New Name",
                CondominiumId = 1,
                HousingType = "Apartment",
                HousingCount = 15,
                Address = "123 Main St Updated",
                UpdatedAt = DateTime.Now
            };

            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(existingBlock);

            // Act
            await _service.UpdateBlockAsync(updatedBlock);

            // Assert
            _mockRepo.Verify(x => x.Update(It.Is<Block>(b => 
                b.Name == "New Name" &&
                b.HousingCount == 15 &&
                b.Address == "123 Main St Updated" &&
                b.UpdatedAt != null)), Times.Once);
            
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteBlockAsync_ShouldSoftDeleteBlock()
        {
            // Arrange
            var blockToDelete = new Block
            {
                Id = 1,
                Name = "Block to delete",
                CondominiumId = 1,
                IsActive = true
            };

            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(blockToDelete);

            // Act
            await _service.DeleteBlockAsync(1);

            // Assert - Verificamos que se llamó a Remove con el bloque correcto
            _mockRepo.Verify(x => x.Remove(It.Is<Block>(b => b.Id == 1)), Times.Once);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteBlockAsync_ShouldDoNothingIfBlockNotFound()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Block)null);

            // Act
            await _service.DeleteBlockAsync(1);

            // Assert
            _mockRepo.Verify(x => x.Remove(It.IsAny<Block>()), Times.Never);
            _mockRepo.Verify(x => x.SaveChangesAsync(), Times.Never);
        }
    }
}