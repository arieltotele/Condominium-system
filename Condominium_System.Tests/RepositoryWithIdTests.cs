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
    public class RepositoryWithIdTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryWithId<Condominium>(context);
            var entity = new Condominium
            {
                Id = 1, 
                Name = "Test",
                Address = "123 Calle Principal",
                ReceptionContactNumber = "809-555-1234",
                BlockCount = 4,

                Author = "TestUser",
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = null,
                DeletedAt = null,

                // Relaciones (vacía para esta prueba)
                Users = new List<User>()
            };

            // Act
            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();

            // Assert
            var all = await repo.GetAllAsync();
            Assert.Single(all);
            Assert.Equal("Test", all.First().Name);
        }
    }

}
