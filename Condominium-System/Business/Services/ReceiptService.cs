using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IRepositoryWithId<Receipt> _receiptRepository;
        private readonly IServiceProvider _serviceProvider;

        public ReceiptService(IRepositoryWithId<Receipt> receiptRepository, IServiceProvider serviceProvider)
        {
            _receiptRepository = receiptRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<Receipt>> GetAllReceiptsAsync()
        {
            return await _receiptRepository.GetAllWithIncludesAsync(
                r => r.Tenant,
                r => r.Housing,
                r => r.Payments
            );
        }

        public async Task<Receipt> GetReceiptByIdAsync(int id)
        {
            return await _receiptRepository.GetByIdWithIncludesAsync(
                id,
                r => r.Tenant,
                r => r.Housing,
                r => r.Payments
            );
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByTenantIdAsync(int tenantId)
        {
            return await _receiptRepository.FindAsync(r =>
                r.TenantId == tenantId && r.AmountPaid < r.Amount);
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByHousingIdAsync(int housingId)
        {
            return await _receiptRepository.FindAsync(r =>
                r.HousingId == housingId);
        }

        public async Task<IEnumerable<Receipt>> GetOverdueReceiptsAsync()
        {
            var currentDate = DateTime.Now;
            return await _receiptRepository.FindAsync(r =>
                r.DueDate < currentDate && r.AmountPaid < r.Amount);
        }

        public async Task<int> GenerateBulkReceiptsAsync(int condominiumId, int year, string author)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var housingService = scope.ServiceProvider.GetRequiredService<IHousingEntityService>();
                var blockService = scope.ServiceProvider.GetRequiredService<IBlockService>();
                var tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();
                var serviceRelationService = scope.ServiceProvider.GetRequiredService<IHousingServiceRelationService>();
                var serviceService = scope.ServiceProvider.GetRequiredService<IServiceService>();

                // Obtener todos los bloques filtrados por condominio
                var blocks = (await blockService.GetBlocksByCondominiumIdAsync(condominiumId)).ToList();

                if (!blocks.Any())
                    return 0;

                var receiptsCreated = 0;
                var currentMonth = DateTime.Now.Month;
                var startMonth = (year == DateTime.Now.Year) ? currentMonth : 1;

                // Para cada bloque, obtener sus viviendas
                foreach (var block in blocks)
                {
                    // Obtener todas las viviendas y filtrar por bloque
                    var allHousings = (await housingService.GetAllHousingsAsync()).ToList();
                    var housings = allHousings.Where(h => h.BlockId == block.Id).ToList();

                    foreach (var housing in housings)
                    {
                        // Obtener todos los inquilinos y filtrar por vivienda
                        var allTenants = (await tenantService.GetAllAsync()).ToList();
                        var tenants = allTenants.Where(t => t.HousingId == housing.Id && t.IsActive).ToList();

                        if (!tenants.Any())
                            continue; // No generar recibos para viviendas sin inquilinos

                        var tenant = tenants.First();

                        // Calcular el monto mensual basado en servicios
                        var monthlyAmount = await CalculateMonthlyAmountAsync(housing.Id, serviceRelationService, serviceService);

                        // Generar recibos desde el mes actual hasta diciembre
                        for (int month = startMonth; month <= 12; month++)
                        {
                            var dueDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1); // Último día del mes

                            var receipt = new Receipt
                            {
                                Date = DateTime.Now,
                                DueDate = dueDate,
                                Amount = monthlyAmount,
                                AmountPaid = 0,
                                Detail = $"Recibo de mantenimiento - {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}",
                                TenantId = tenant.Id,
                                HousingId = housing.Id,
                                Author = "System",
                                CreatedAt = DateTime.Now,
                                IsActive = true
                            };

                            await CreateReceiptAsync(receipt);
                            receiptsCreated++;
                        }
                    }
                }

                return receiptsCreated;
            }
        }

        private async Task<int> CalculateMonthlyAmountAsync(int housingId,
            IHousingServiceRelationService housingServiceRelationService,
            IServiceService serviceService)
        {
            try
            {
                // Obtener servicios activos de la vivienda
                var housingServices = await housingServiceRelationService.GetAllAsync();
                var activeServices = housingServices
                    .Where(hs => hs.HousingId == housingId && hs.IsActive)
                    .ToList();

                int totalAmount = 0;

                foreach (var housingService in activeServices)
                {
                    // Obtener el servicio para obtener el costo
                    var service = await serviceService.GetByIdAsync(housingService.ServiceId);
                    if (service != null && service.IsActive)
                    {
                        totalAmount += service.Cost;
                    }
                }

                return totalAmount;
            }
            catch
            {
                // En caso de error, retornar un monto base o 0
                return 0;
            }
        }

        public async Task<Receipt> CreateReceiptAsync(Receipt receipt)
        {
            await _receiptRepository.AddAsync(receipt);
            await _receiptRepository.SaveChangesAsync();
            return receipt;
        }

        public async Task UpdateReceiptAsync(Receipt receipt)
        {
            _receiptRepository.Update(receipt);
            await _receiptRepository.SaveChangesAsync();
        }

        public async Task DeleteReceiptAsync(int id)
        {
            var receipt = await _receiptRepository.GetByIdAsync(id);
            if (receipt != null)
            {
                _receiptRepository.Remove(receipt);
                await _receiptRepository.SaveChangesAsync();
            }
        }

        public async Task<int> GetTotalAmountDueAsync(int tenantId)
        {
            var receipts = await GetReceiptsByTenantIdAsync(tenantId);
            return receipts.Sum(r => r.Amount - r.AmountPaid);
        }
    }
}
