using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IRepositoryWithId<Receipt> _receiptRepository;

        public ReceiptService(IRepositoryWithId<Receipt> receiptRepository)
        {
            _receiptRepository = receiptRepository;
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
