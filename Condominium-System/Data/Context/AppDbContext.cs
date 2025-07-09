using Condominium_System.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Housing> Housings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<HousingService> HousingServices { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<HousingFurniture> HousingFurnitures { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ========= Uniques =========

            modelBuilder.Entity<Condominium>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.DocumentNumber)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // ========= Relations with Foreign Key =========

            // User -> Condominium
            modelBuilder.Entity<User>()
                .HasOne(u => u.Condominium)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CondominiumId)
                .OnDelete(DeleteBehavior.Cascade);

            // Block -> Condominium
            modelBuilder.Entity<Block>()
                .HasOne(b => b.Condominium)
                .WithMany(c => c.Blocks)
                .HasForeignKey(b => b.CondominiumId)
                .OnDelete(DeleteBehavior.Cascade);

            // Housing -> Block
            modelBuilder.Entity<Housing>()
                .HasOne(h => h.Block)
                .WithMany(b => b.Housings)
                .HasForeignKey(h => h.BlockId)
                .OnDelete(DeleteBehavior.Cascade);

            // Tenant -> Housing
            modelBuilder.Entity<Tenant>()
                .HasOne(t => t.Housing)
                .WithMany(h => h.Tenants)
                .HasForeignKey(t => t.HousingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Incident -> Tenant
            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Tenant)
                .WithMany(t => t.Incidents)
                .HasForeignKey(i => i.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Invoice -> Tenant
            modelBuilder.Entity<Invoice>()
                .HasOne(f => f.Tenant)
                .WithMany(t => t.Invoices)
                .HasForeignKey(f => f.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            // ========= HousingService (many-to-many with composite key) =========

            modelBuilder.Entity<HousingService>()
                .HasKey(hs => new { hs.HousingId, hs.ServiceId });

            modelBuilder.Entity<HousingService>()
                .HasOne(hs => hs.Housing)
                .WithMany(h => h.Services)
                .HasForeignKey(hs => hs.HousingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HousingService>()
                .HasOne(hs => hs.Service)
                .WithMany(s => s.Housings)
                .HasForeignKey(hs => hs.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // ========= HousingFurniture (many-to-many with composite key) =========

            modelBuilder.Entity<HousingFurniture>()
                .HasKey(hf => new { hf.HousingId, hf.FurnitureId });

            modelBuilder.Entity<HousingFurniture>()
                .HasOne(hf => hf.Housing)
                .WithMany(h => h.Furnitures)
                .HasForeignKey(hf => hf.HousingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HousingFurniture>()
                .HasOne(hf => hf.Furniture)
                .WithMany(f => f.Housings)
                .HasForeignKey(hf => hf.FurnitureId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void SeedInitialSuperUser()
        {
            if (!Users.Any(u => u.Type == "SuperUsuario"))
            {
                Users.Add(new User
                {
                    FirstName = "Admin",
                    LastName = "General",
                    DocumentNumber = "000000000",
                    PhoneNumber = "0000000000",
                    Username = "admin",
                    Password = "admin123",
                    Type = "SuperUsuario",
                    IsActive = true,
                    Author = "System",
                    CreatedAt = DateTime.Now
                });

                SaveChanges();
            }
        }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Cargar configuración desde appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") // Asegúrate que el archivo exista en la ruta
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies(); // si usas proxies

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
