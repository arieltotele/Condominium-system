using Microsoft.EntityFrameworkCore;

using Condominium_System.Data.Context;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Condominium_System.Business.Services;

public class IncidentServiceTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // BD única por test
            .UseLazyLoadingProxies()
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateAndGetIncident_ShouldReturnIncidentWithTenant()
    {
        // Arrange
        var context = GetDbContext();

        var tenantRepo = new RepositoryWithId<Tenant>(context);
        var incidentRepo = new RepositoryWithId<Incident>(context);

        var service = new IncidentService(incidentRepo, tenantRepo);

        // Creamos un Tenant completo
        var tenant = new Tenant
        {
            FirstName = "Juan",
            LastName = "Pérez",
            DocumentNumber = "123456789",
            PhoneNumber = "8090000000",
            Gender = "Masculino",
            HousingId = 1,
            Author = "Test",
            IsActive = true,
            CreatedAt = DateTime.Now
        };
        await tenantRepo.AddAsync(tenant);
        await tenantRepo.SaveChangesAsync();

        // Act - creamos el incidente
        var incident = new Incident
        {
            Description = "Fuga de agua",
            Date = DateTime.Now,
            TenantId = tenant.Id,
            Tenant = tenant,
            Author = "Test",
            IsActive = true,
            CreatedAt = DateTime.Now
        };

        await service.CreateAsync(incident);

        // Assert
        var savedIncident = await service.GetByIdAsync(incident.Id);

        Assert.NotNull(savedIncident);
        Assert.Equal("Fuga de agua", savedIncident.Description);
        Assert.NotNull(savedIncident.Tenant);
        Assert.Equal("Juan", savedIncident.Tenant.FirstName);
    }

    [Fact]
    public async Task SearchIncidents_ShouldFindByDescription()
    {
        var context = GetDbContext();

        var tenantRepo = new RepositoryWithId<Tenant>(context);
        var incidentRepo = new RepositoryWithId<Incident>(context);

        var service = new IncidentService(incidentRepo, tenantRepo);

        // Creamos Tenant
        var tenant = new Tenant
        {
            FirstName = "Ana",
            LastName = "López",
            DocumentNumber = "987654321",
            PhoneNumber = "8091111111",
            Gender = "Femenino",
            HousingId = 1,
            Author = "Test",
            IsActive = true,
            CreatedAt = DateTime.Now
        };
        await tenantRepo.AddAsync(tenant);
        await tenantRepo.SaveChangesAsync();

        // Creamos incidente
        await service.CreateAsync(new Incident
        {
            Description = "Problema eléctrico",
            Date = DateTime.Now,
            TenantId = tenant.Id,
            Tenant = tenant,
            Author = "Test",
            IsActive = true,
            CreatedAt = DateTime.Now
        });

        // Act
        var found = await service.SearchIncidentsAsync("eléctrico");

        // Assert
        Assert.Single(found);
        Assert.Contains("eléctrico", found.First().Description, StringComparison.OrdinalIgnoreCase);
    }
}
