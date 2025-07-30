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

        [Fact]
        public async Task Remove_ShouldMarkEntityAsInactive_WhenAuditable()
        {
            // Arrange
            var _context = GetInMemoryDbContext();
            var _repository = new RepositoryWithId<Condominium>(_context);
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
                Users = new List<User>()
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            _repository.Remove(entity);
            await _repository.SaveChangesAsync();

            var all = await _repository.GetAllAsync();
            Assert.DoesNotContain(all, c => c.Id == entity.Id);

            var fromDb = await _context.Condominiums.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == entity.Id);
            Assert.NotNull(fromDb);
            Assert.False(fromDb.IsActive);
            Assert.NotNull(fromDb.DeletedAt);
        }

        [Fact]
        public async Task GetAllWithIncludesAsync_ShouldReturnOnlyActiveEntitiesWithIncludedData()
        {
            // Arrange
            var _context = GetInMemoryDbContext();
            var _repository = new RepositoryWithId<Condominium>(_context);

            var condoActive = new Condominium
            {
                Name = "Activo",
                Address = "Calle 1",
                ReceptionContactNumber = "123456789",
                BlockCount = 2,
                Author = "TestUser",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                Users = new List<User>
                {
                    new User
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        DocumentNumber = "123456789",
                        PhoneNumber = "8095551234",
                        Username = "johndoe",
                        Password = "securepass123",
                        Type = "Admin",
                        Author = "TestUser",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    }
                }
            };

            var condoInactive = new Condominium
            {
                Name = "Inactivo",
                Address = "Calle 2",
                ReceptionContactNumber = "987654321",
                BlockCount = 1,
                Author = "TestUser",
                CreatedAt = DateTime.UtcNow,
                IsActive = false,
                Users = new List<User>
                {
                    new User
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        DocumentNumber = "987654321",
                        PhoneNumber = "8095555678",
                        Username = "janesmith",
                        Password = "securepass456",
                        Type = "Manager",
                        Author = "TestUser",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    }
                }
            };

            await _repository.AddAsync(condoActive);
            await _repository.AddAsync(condoInactive);
            await _repository.SaveChangesAsync();

            // Act
            var results = await _repository.GetAllWithIncludesAsync(c => c.Users);

            // Assert
            var resultList = results.ToList();
            Assert.Single(resultList);

            var result = resultList.First();
            Assert.Equal("Activo", result.Name);
            Assert.NotNull(result.Users);
            Assert.Single(result.Users);
            Assert.Equal("johndoe", result.Users.First().Username); // Corregido para que coincida con Username
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntityOnlyIfActive()
        {
            // Arrange
            var _context = GetInMemoryDbContext();
            var _repository = new RepositoryWithId<Condominium>(_context);

            var activeCondo = new Condominium
            {
                Name = "Activo",
                Address = "Calle 1",
                ReceptionContactNumber = "123456789",
                BlockCount = 2,
                Author = "TestUser",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var inactiveCondo = new Condominium
            {
                Name = "Inactivo",
                Address = "Calle 2",
                ReceptionContactNumber = "987654321",
                BlockCount = 1,
                Author = "TestUser",
                IsActive = false,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(activeCondo);
            await _repository.AddAsync(inactiveCondo);
            await _repository.SaveChangesAsync();

            // Act
            var foundActive = await _repository.GetByIdAsync(activeCondo.Id);
            var foundInactive = await _repository.GetByIdAsync(inactiveCondo.Id);

            // Assert
            Assert.NotNull(foundActive);
            Assert.Equal("Activo", foundActive.Name);

            Assert.Null(foundInactive);
        }

        [Fact]
        public async Task GetByIdWithIncludesAsync_ShouldIncludeFurnituresAndRespectIsActive()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryWithId<Housing>(context);

            var furniture1 = new Furniture
            {
                Id = 1,
                Name = "Silla",
                Detail = "Silla de madera",
                Type = "Mobiliario",
                Author = "TestUser",
                IsActive = true
            };
            var furniture2 = new Furniture
            {
                Id = 2,
                Name = "Mesa",
                Detail = "Mesa de comedor",
                Type = "Mobiliario",
                Author = "TestUser",
                IsActive = true
            };

            var housingActive = new Housing
            {
                Id = 1,
                Code = "H001",
                PeopleCount = 3,
                RoomCount = 2,
                BathroomCount = 1,
                IsActive = true,
                Furnitures = new List<HousingFurniture>
                {
                    new HousingFurniture { HousingId = 1, FurnitureId = 1, Author = "TestUser", Furniture = furniture1 },
                    new HousingFurniture { HousingId = 1, FurnitureId = 2, Author = "TestUser", Furniture = furniture2 }
                },
                Author = "TestUser",
            };

            var housingInactive = new Housing
            {
                Id = 2,
                Code = "H002",
                PeopleCount = 4,
                RoomCount = 3,
                BathroomCount = 2,
                Author = "TestUser",
                IsActive = false
            };

            context.Housings.AddRange(housingActive, housingInactive);
            await context.SaveChangesAsync();

            // Act
            var result = await repo.GetByIdWithIncludesAsync(1, h => h.Furnitures);
            var resultInactive = await repo.GetByIdWithIncludesAsync(2, h => h.Furnitures);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Furnitures.Count);

            Assert.Null(resultInactive);
        }

        [Fact]
        public async Task FindAsync_ShouldReturnTenantsMatchingPredicate_AndOnlyActive()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryWithId<Tenant>(context);

            var tenant1 = new Tenant
            {
                Id = 1,
                FirstName = "Juan",
                LastName = "Perez",
                DocumentNumber = "123456789",
                Gender = "M",
                PhoneNumber = "8091234567",
                IsActive = true,
                Author = "TestUser"
            };
            var tenant2 = new Tenant
            {
                Id = 2,
                FirstName = "Pedro",
                LastName = "Gomez",
                DocumentNumber = "987654321",
                Gender = "M",
                PhoneNumber = "8097654321",
                IsActive = false,
                Author = "TestUser"
            };
            var tenant3 = new Tenant
            {
                Id = 3,
                FirstName = "Juana",
                LastName = "Lopez",
                DocumentNumber = "456789123",
                Gender = "F",
                PhoneNumber = "8094567890",
                IsActive = true,
                Author = "TestUser"
            };

            context.Tenants.AddRange(tenant1, tenant2, tenant3);
            await context.SaveChangesAsync();

            // Act
            var results = await repo.FindAsync(t => t.FirstName.Contains("Ju"));

            // Assert
            Assert.Contains(results, t => t.FirstName == "Juan");
            Assert.Contains(results, t => t.FirstName == "Juana");
            Assert.DoesNotContain(results, t => t.FirstName == "Pedro");
        }

        [Fact]
        public async Task Update_ShouldMarkBlockAsModified()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryWithId<Block>(context);

            var block = new Block
            {
                Id = 1,
                Name = "Bloque Original",
                Feature = "Característica A",
                HousingType = "Tipo Residencial",
                HousingCount = 10,
                Address = "Calle Falsa 123",
                CondominiumId = 1,
                Author = "TestUser"
            };
            context.Blocks.Add(block);
            await context.SaveChangesAsync();

            // Modificación
            block.Name = "Bloque Modificado";

            // Act
            repo.Update(block);
            var entry = context.Entry(block);

            // Assert
            Assert.Equal(EntityState.Modified, entry.State);
        }

        [Fact]
        public async Task Remove_ShouldSetIsActiveFalseAndDeletedAt_ForAuditableBlock()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryWithId<Block>(context);

            var block = new Block
            {
                Id = 1,
                Name = "Bloque a eliminar",
                Feature = "Característica B",
                HousingType = "Tipo Comercial",
                HousingCount = 5,
                Address = "Avenida Principal 456",
                CondominiumId = 1,
                Author = "TestUser"
            };
            context.Blocks.Add(block);
            await context.SaveChangesAsync();

            // Act
            repo.Remove(block);
            await repo.SaveChangesAsync();

            var updated = await context.Blocks.FindAsync(1);

            // Assert
            Assert.False(updated!.IsActive);
            Assert.NotNull(updated.DeletedAt);
        }

        [Fact]
        public async Task Remove_ShouldSoftDeleteService()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryWithId<Service>(context);

            var service = new Service
            {
                Id = 1,
                Name = "Servicio a eliminar",
                Detail = "Detalle de prueba",
                Cost = 100,
                Type = "Tipo1",
                Author = "TestUser"
            };
            context.Services.Add(service);
            await context.SaveChangesAsync();

            // Act
            repo.Remove(service);          // Soft delete (IsActive = false)
            await repo.SaveChangesAsync();

            var updated = await context.Services.FindAsync(1);

            // Assert
            Assert.NotNull(updated);       // No se elimina físicamente
            Assert.False(updated.IsActive);
            Assert.NotNull(updated.DeletedAt);
        }
        
        [Fact]
        public async Task SaveChangesAsync_ShouldPersistNewCondominium()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new RepositoryWithId<Condominium>(context);

            var condo = new Condominium 
            { 
                Id = 1, 
                Name = "Nuevo Condominio", 
                Address = "Calle X",
                ReceptionContactNumber = "809-555-5555",
                Author = "TestUser"
            };

            await repo.AddAsync(condo);

            // Act
            await repo.SaveChangesAsync();

            // Assert
            var saved = await context.Condominiums.FindAsync(1);
            Assert.NotNull(saved);
            Assert.Equal("Nuevo Condominio", saved.Name);
            Assert.Equal("809-555-5555", saved.ReceptionContactNumber);
            Assert.Equal("TestUser", saved.Author);
        }

    }
}
