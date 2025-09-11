using Moq;
using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Condominium_System.Data.Context;

namespace Condominium_System.Tests.Services
{
    public class HousingFurnitureServiceTests
    {
        private readonly Mock<IRepositoryNoId<HousingFurniture>> _mockRepo;
        private readonly HousingFurnitureService _service;

        public HousingFurnitureServiceTests()
        {
            _mockRepo = new Mock<IRepositoryNoId<HousingFurniture>>();
            _service = new HousingFurnitureService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllItems()
        {
            var items = new List<HousingFurniture>
            {
                new HousingFurniture 
                { 
                    HousingId = 1, 
                    FurnitureId = 1,
                    Housing = new Housing { Id = 1, Code = "A101" },
                    Furniture = new Furniture { Id = 1, Name = "Sofa" }
                },
                new HousingFurniture 
                { 
                    HousingId = 2, 
                    FurnitureId = 2,
                    Housing = new Housing { Id = 2, Code = "B202" },
                    Furniture = new Furniture { Id = 2, Name = "Mesa" }
                }
            };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(items);

            var result = await _service.GetAllAsync();

            Assert.Equal(2, result.Count());
            Assert.Contains(result, x => x.Housing.Code == "A101" && x.Furniture.Name == "Sofa");
        }

        [Fact]
        public async Task GetByIdsAsync_ReturnsCorrectItem()
        {
            var item = new HousingFurniture
            {
                HousingId = 1,
                FurnitureId = 1,
                Housing = new Housing { Id = 1, Code = "A101" },
                Furniture = new Furniture { Id = 1, Name = "Sofa" }
            };

            _mockRepo.Setup(r => r.FindAsync(
                It.IsAny<System.Linq.Expressions.Expression<System.Func<HousingFurniture, bool>>>(),
                true
            )).ReturnsAsync(new List<HousingFurniture> { item });

            var result = await _service.GetByIdsAsync(1, 1);

            Assert.NotNull(result);
            Assert.Equal("A101", result.Housing.Code);
            Assert.Equal("Sofa", result.Furniture.Name);
        }

        [Fact]
        public async Task CreateAsync_AddsItem()
        {
            var item = new HousingFurniture
            {
                HousingId = 1,
                FurnitureId = 1,
                Housing = new Housing { Id = 1, Code = "A101" },
                Furniture = new Furniture { Id = 1, Name = "Sofa" }
            };

            _mockRepo.Setup(r => r.AddAsync(item)).Returns(Task.CompletedTask);
            _mockRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            var result = await _service.CreateAsync(item);

            _mockRepo.Verify(r => r.AddAsync(item), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.Equal("A101", result.Housing.Code);
        }

        [Fact]
        public async Task DeleteAsync_RemovesItem()
        {
            var item = new HousingFurniture
            {
                HousingId = 1,
                FurnitureId = 1,
                Housing = new Housing { Id = 1, Code = "A101" },
                Furniture = new Furniture { Id = 1, Name = "Sofa" }
            };

            _mockRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<HousingFurniture, bool>>>(), true))
                     .ReturnsAsync(new List<HousingFurniture> { item });
            _mockRepo.Setup(r => r.Remove(item));
            _mockRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            await _service.DeleteAsync(1, 1);

            _mockRepo.Verify(r => r.Remove(item), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesItem()
        {
            var housing = new Housing
            {
                Id = 1,
                Code = "A101",
                PeopleCount = 4,
                RoomCount = 2,
                BathroomCount = 1,
                BlockId = 1,
                Block = new Block { Id = 1, Name = "Bloque A" },
                Services = new List<HousingService>(),
                Furnitures = new List<HousingFurniture>(),
                Tenants = new List<Tenant>(),
                Receipts = new List<Receipt>()
            };

            var furniture = new Furniture
            {
                Id = 1,
                Name = "Sofa",
                Detail = "Sofa de 3 plazas",
                Type = "Living",
                Housings = new List<HousingFurniture>()
            };

            var item = new HousingFurniture
            {
                HousingId = housing.Id,
                FurnitureId = furniture.Id,
                Housing = housing,
                Furniture = furniture
            };

            // Mock de Update y SaveChanges
            _mockRepo.Setup(r => r.Update(item));
            _mockRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            // ===== Crear un AppDbContext real en memoria y devolverlo desde el mock =====
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // BD única por test
                .Options;

            var realContext = new AppDbContext(options);

            // (Opcional) si tu repo espera tablas existentes, puedes añadir entidades al context y guardarlas:
            // realContext.Housings.Add(housing);
            // realContext.Furnitures.Add(furniture);
            // await realContext.SaveChangesAsync();

            _mockRepo.SetupGet(r => r.Context).Returns(realContext);

            await _service.UpdateAsync(item);

            _mockRepo.Verify(r => r.Update(item), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);

            // Dispose al final si quieres
            realContext.Dispose();
        }

        [Fact]
        public async Task DeleteAllByHousingIdAsync_RemovesAll()
        {
            var items = new List<HousingFurniture>
            {
                new HousingFurniture { HousingId = 1, FurnitureId = 1 },
                new HousingFurniture { HousingId = 1, FurnitureId = 2 }
            };

            _mockRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<HousingFurniture, bool>>>(), false))
                     .ReturnsAsync(items);
            _mockRepo.Setup(r => r.RemoveRange(items));
            _mockRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            await _service.DeleteAllByHousingIdAsync(1);

            _mockRepo.Verify(r => r.RemoveRange(items), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateRangeAsync_AddsMultipleItems()
        {
            var items = new List<HousingFurniture>
            {
                new HousingFurniture { HousingId = 1, FurnitureId = 1 },
                new HousingFurniture { HousingId = 1, FurnitureId = 2 }
            };

            _mockRepo.Setup(r => r.AddRangeAsync(items)).Returns(Task.CompletedTask);
            _mockRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            await _service.CreateRangeAsync(items);

            _mockRepo.Verify(r => r.AddRangeAsync(items), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
