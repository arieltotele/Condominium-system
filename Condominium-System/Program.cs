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

            // Registration for formularies
            services.AddScoped<Login>();
            services.AddScoped<HomeScreen>();
            services.AddScoped<UsersScreen>();
            services.AddScoped<SignUpScreen>();
            services.AddScoped<CondominiumScreen>();

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