using Condominium_System.Business.Services;
using Condominium_System.Data.Context;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Condominium_System.Presentation.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Condominium_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });

            // Registration for services and repositories
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepositoryWithId<User>, RepositoryWithId<User>>();

            services.AddScoped<ICondominiumService, CondominiumService>();
            services.AddScoped<IRepositoryWithId<Condominium>, RepositoryWithId<Condominium>>();

            services.AddScoped<IBlockService, BlockService>();
            services.AddScoped<IRepositoryWithId<Block>, RepositoryWithId<Block>>();

            services.AddScoped<IFurnitureService, FurnitureService>();
            services.AddScoped<IRepositoryWithId<Furniture>, RepositoryWithId<Furniture>>();

            services.AddScoped<IHousingEntityService, HousingEntityService>();
            services.AddScoped<IRepositoryWithId<Housing>, RepositoryWithId<Housing>>();

            services.AddScoped<IHousingFurnitureService, HousingFurnitureService>();
            services.AddScoped<IRepositoryNoId<HousingFurniture>, RepositoryNoId<HousingFurniture>>();

            services.AddScoped<IHousingServiceRelationService, HousingServiceRelationService>();
            services.AddScoped<IRepositoryNoId<HousingService>, RepositoryNoId<HousingService>>();

            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<IRepositoryWithId<Incident>, RepositoryWithId<Incident>>();

            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IRepositoryWithId<Invoice>, RepositoryWithId<Invoice>>();

            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IRepositoryWithId<Service>, RepositoryWithId<Service>>();

            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IRepositoryWithId<Tenant>, RepositoryWithId<Tenant>>();


            // Registration for formularies
            services.AddTransient<HomeScreen>();
            services.AddTransient<Login>();
            services.AddTransient<SignUpScreen>();
            services.AddTransient<UsersScreen>();
            services.AddTransient<ServiceScreen>();
            services.AddTransient<HousingScreen>();
            services.AddTransient<HousingBlocksScreen>();
            services.AddTransient<CondominiumScreen>();
            services.AddTransient<TenantScreen>();
            services.AddTransient<IncidenceScreen>();
            services.AddTransient<InvoiceScreen>();
            services.AddTransient<FurnitureScreen>();
            services.AddTransient<AddFurnitureScreen>();
            services.AddTransient<AddServiceScreen>();
            services.AddTransient<UpsertCondominiumScreen>();
            services.AddTransient<UpsertHousingBlocks>();
            services.AddTransient<UpsertTenantScreen>();
            services.AddTransient<UpsertIncidenceScreen>();
            services.AddTransient<UpsertFurnitureScreen>();

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.Migrate();
                context.SeedInitialSuperUser();

                var loginForm = scope.ServiceProvider.GetRequiredService<Login>();
                Application.Run(loginForm);
            }
        }
    }
}