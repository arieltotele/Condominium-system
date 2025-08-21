using Condominium_System.Data.Context;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Condominium_System.Tests
{
    public class RepositoryNoIdTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnOnlyActiveHousingFurniture()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryNoId<HousingFurniture>(context);

            var hf1 = new HousingFurniture
            {
                HousingId = 1,
                FurnitureId = 1,
                IsActive = true,
                Author = "TestUser"
            };
            var hf2 = new HousingFurniture
            {
                HousingId = 2,
                FurnitureId = 2,
                IsActive = false,
                Author = "TestUser"
            };

            context.AddRange(hf1, hf2);
            await context.SaveChangesAsync();

            // Act
            var results = await repo.GetAllAsync();

            // Assert
            Assert.Single(results);
            Assert.Contains(results, hf => hf.HousingId == 1 && hf.FurnitureId == 1);
        }

        [Fact]
        public async Task FindAsync_ShouldFilterAndReturnOnlyActive()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryNoId<HousingFurniture>(context);

            var hf1 = new HousingFurniture { HousingId = 1, FurnitureId = 1, IsActive = true, Author = "TestUser" };
            var hf2 = new HousingFurniture { HousingId = 2, FurnitureId = 2, IsActive = false, Author = "TestUser" };

            context.AddRange(hf1, hf2);
            await context.SaveChangesAsync();

            // Act
            var results = await repo.FindAsync(hf => hf.HousingId == 1);

            // Assert
            Assert.Single(results);
            Assert.All(results, hf => Assert.True(hf.IsActive));
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryNoId<HousingFurniture>(context);

            var hf = new HousingFurniture { HousingId = 10, FurnitureId = 20, Author = "TestUser" };

            // Act
            await repo.AddAsync(hf);
            await repo.SaveChangesAsync();

            var added = await context.HousingFurnitures.FindAsync(10, 20);

            // Assert
            Assert.NotNull(added);
            Assert.Equal(10, added.HousingId);
            Assert.Equal(20, added.FurnitureId);
        }

        [Fact]
        public async Task Update_ShouldMarkEntityAsModified()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryNoId<HousingFurniture>(context);

            var hf = new HousingFurniture { HousingId = 1, FurnitureId = 1, Author = "TestUser" };
            context.HousingFurnitures.Add(hf);
            await context.SaveChangesAsync();

            // Para simular una modificación, podemos cambiar la propiedad Author, por ejemplo
            hf.Author = "TestUserUpdated";

            // Act
            repo.Update(hf);

            var entry = context.Entry(hf);

            // Assert
            Assert.Equal(EntityState.Modified, entry.State);
        }

        [Fact]
        public async Task Remove_ShouldSoftDeleteEntity()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryNoId<HousingFurniture>(context);

            var hf = new HousingFurniture { HousingId = 1, FurnitureId = 1, Author = "TestUser" };
            context.HousingFurnitures.Add(hf);
            await context.SaveChangesAsync();

            // Act
            repo.Remove(hf);
            await repo.SaveChangesAsync();

            var updated = await context.HousingFurnitures.FindAsync(1, 1);

            // Assert
            Assert.NotNull(updated);
            Assert.False(updated.IsActive);
            Assert.NotNull(updated.DeletedAt);
        }

        [Fact]
        public async Task SaveChangesAsync_ShouldPersistChanges()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryNoId<HousingFurniture>(context);

            var hf = new HousingFurniture { HousingId = 5, FurnitureId = 6, Author = "TestUser" };

            await repo.AddAsync(hf);

            // Act
            await repo.SaveChangesAsync();

            var saved = await context.HousingFurnitures.FindAsync(5, 6);

            // Assert
            Assert.NotNull(saved);
            Assert.Equal(5, saved.HousingId);
            Assert.Equal(6, saved.FurnitureId);
        }


    }
}