using Condominium_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public interface IReceiptService
    {
        Task<IEnumerable<Receipt>> GetAllReceiptsAsync();
        Task<Receipt> GetReceiptByIdAsync(int id);
        Task<IEnumerable<Receipt>> GetReceiptsByTenantIdAsync(int tenantId);
        Task<IEnumerable<Receipt>> GetReceiptsByHousingIdAsync(int housingId);
        Task<IEnumerable<Receipt>> GetOverdueReceiptsAsync();
        Task<Receipt> CreateReceiptAsync(Receipt receipt);
        Task UpdateReceiptAsync(Receipt receipt);
        Task DeleteReceiptAsync(int id);
        Task<int> GetTotalAmountDueAsync(int tenantId);
    }
}
