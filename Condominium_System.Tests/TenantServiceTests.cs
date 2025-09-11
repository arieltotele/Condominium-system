using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using FluentAssertions;

public class TenantServiceTests
{
    [Fact]
    public async Task CalculateTotalServicesByTenantAsync_ReturnsCorrectSum()
    {
        // Arrange
        var context = InMemoryDbContextFactory.Create(Guid.NewGuid().ToString());

        // Creamos datos completos
        var condominium = new Condominium
        {
            Name = "Condo A",
            Address = "Main Street",
            ReceptionContactNumber = "809-000-0000",
            BlockCount = 1,
            Quota = 1000,
            Author = "Test"
        };
        await context.Condominiums.AddAsync(condominium);
        await context.SaveChangesAsync();

        var block = new Block
        {
            Name = "Block 1",
            Feature = "Piscina",
            HousingType = "Apartamento",
            HousingCount = 1,
            Address = "Calle 1",
            CondominiumId = condominium.Id,
            Author = "Test"
        };
        await context.Blocks.AddAsync(block);
        await context.SaveChangesAsync();

        var housing = new Housing
        {
            Code = "H-101",
            PeopleCount = 3,
            RoomCount = 2,
            BathroomCount = 1,
            BlockId = block.Id,
            Author = "Test"
        };
        await context.Housings.AddAsync(housing);
        await context.SaveChangesAsync();

        var tenant = new Tenant
        {
            FirstName = "Juan",
            LastName = "Pérez",
            DocumentNumber = "00112233",
            PhoneNumber = "8091112222",
            BirthDate = new DateTime(1990, 1, 1),
            Gender = "M",
            EntryDate = DateTime.Today,
            HousingId = housing.Id,
            Author = "Test"
        };
        await context.Tenants.AddAsync(tenant);
        await context.SaveChangesAsync();

        var service1 = new Service
        {
            Name = "Agua",
            Detail = "Servicio de agua",
            Cost = 500,
            Type = "Mensual",
            Author = "Test"
        };
        var service2 = new Service
        {
            Name = "Basura",
            Detail = "Recolección de basura",
            Cost = 300,
            Type = "Mensual",
            Author = "Test"
        };
        await context.Services.AddRangeAsync(service1, service2);
        await context.SaveChangesAsync();

        var hs1 = new HousingService
        {
            HousingId = housing.Id,
            ServiceId = service1.Id,
            Author = "Test",
            IsActive = true
        };
        var hs2 = new HousingService
        {
            HousingId = housing.Id,
            ServiceId = service2.Id,
            Author = "Test",
            IsActive = true
        };
        await context.HousingServices.AddRangeAsync(hs1, hs2);
        await context.SaveChangesAsync();

        // Repositorios reales con EF InMemory
        var tenantRepo = new RepositoryWithId<Tenant>(context);
        var housingServiceRepo = new RepositoryNoId<HousingService>(context);

        var service = new TenantService(tenantRepo, housingServiceRepo);

        // Act
        var total = await service.CalculateTotalServicesByTenantAsync(tenant.Id);

        // Assert
        total.Should().Be(800); // 500 + 300
    }

    [Fact]
    public async Task CreateAndSearchTenant_Works()
    {
        var context = InMemoryDbContextFactory.Create(Guid.NewGuid().ToString());

        var housing = new Housing
        {
            Code = "H-202",
            PeopleCount = 2,
            RoomCount = 1,
            BathroomCount = 1,
            BlockId = 0, // puedes crear block/condo también
            Author = "Test"
        };
        context.Housings.Add(housing);
        context.SaveChanges();

        var tenantRepo = new RepositoryWithId<Tenant>(context);
        var housingServiceRepo = new RepositoryNoId<HousingService>(context);
        var service = new TenantService(tenantRepo, housingServiceRepo);

        var tenant = new Tenant
        {
            FirstName = "Maria",
            LastName = "Lopez",
            DocumentNumber = "998877",
            PhoneNumber = "8093334444",
            BirthDate = DateTime.Today.AddYears(-30),
            Gender = "F",
            EntryDate = DateTime.Today,
            HousingId = housing.Id,
            Author = "Test"
        };

        await service.CreateAsync(tenant);

        var result = await service.SearchTenantsAsync("Maria");

        result.Should().ContainSingle();
    }
}
