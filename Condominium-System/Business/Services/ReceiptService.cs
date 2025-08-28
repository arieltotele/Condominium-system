using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Condominium_System.Helpers.Status;
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

        public async Task<IEnumerable<Receipt>> GetReceiptsByStatusAsync(string status)
        {
            if (!ReceiptStatusHelper.IsValidStatus(status))
                throw new ArgumentException("Estatus no válido");

            return await _receiptRepository.FindAsync(r =>
                r.Status == status && r.IsActive);
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByStatusAndHousingAsync(int housingId, params string[] statuses)
        {
            if (housingId <= 0)
                throw new ArgumentException("ID de vivienda inválido");

            if (statuses == null || statuses.Length == 0)
                return Enumerable.Empty<Receipt>();

            // Obtener todos los recibos y filtrar
            var allReceipts = await _receiptRepository.GetAllWithIncludesAsync(
                r => r.Tenant,
                r => r.Housing,
                r => r.Payments
            );

            return allReceipts.Where(r =>
                r.HousingId == housingId &&
                statuses.Contains(r.Status) &&
                r.IsActive);
        }

        public async Task<int> GenerateBulkReceiptsAsync(int condominiumId, int year, string author)
        {
            if (year < DateTime.Now.Year)
            {
                throw new ArgumentException("No se pueden generar recibos para años anteriores");
            }

            // Validar que el autor no esté vacío
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Se requiere un autor para generar recibos");
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var condominiumService = scope.ServiceProvider.GetRequiredService<ICondominiumService>();
                var housingService = scope.ServiceProvider.GetRequiredService<IHousingEntityService>();
                var blockService = scope.ServiceProvider.GetRequiredService<IBlockService>();
                var tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();

                // Obtener el condominio para sacar la quota
                var condominium = await condominiumService.GetCondominiumByIdAsync(condominiumId);
                if (condominium == null)
                {
                    throw new Exception("Condominio no encontrado");
                }

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

                        var monthlyAmount = condominium.Quota;

                        // Generar recibos desde el mes actual hasta diciembre
                        for (int month = startMonth; month <= 12; month++)
                        {
                            var dueDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);

                            var receipt = new Receipt
                            {
                                Date = DateTime.Now,
                                DueDate = dueDate,
                                Amount = monthlyAmount,
                                AmountPaid = 0,
                                Detail = $"Recibo de mantenimiento - {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}",
                                Status = ReceiptStatusHelper.Pending,
                                TenantId = tenant.Id,
                                HousingId = housing.Id,
                                Author = author,
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
