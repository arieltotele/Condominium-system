using Microsoft.EntityFrameworkCore;
using Condominium_System.Data.Context;

public class InMemoryDbContextFactory
{
    public static AppDbContext Create(string dbName)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .UseLazyLoadingProxies() // si en tu prod usas proxies
            .Options;

        var context = new AppDbContext(options);
        return context;
    }
}
