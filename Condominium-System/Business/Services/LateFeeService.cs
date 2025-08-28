using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class LateFeeService : ILateFeeService
    {
        private readonly IRepositoryWithId<Receipt> _receiptRepository;

        public LateFeeService(IRepositoryWithId<Receipt> receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<int> CalculateLateFeeAsync(int receiptId)
        {
            var receipt = await _receiptRepository.GetByIdAsync(receiptId);
            if (receipt == null) return 0;

            // Solo calcular mora si ya pasó la fecha límite y no se ha aplicado
            if (DateTime.Now > receipt.DueDate && !receipt.LateFeeApplied)
            {
                int daysLate = (DateTime.Now - receipt.DueDate).Days;

                // Calcular mora: 5% del monto total por cada mes de retraso (o fracción)
                decimal monthlyFee = receipt.Amount * 0.05m;
                int monthsLate = (int)Math.Ceiling(daysLate / 30.0);

                return (int)(monthlyFee * monthsLate);
            }

            return 0;
        }

        public async Task<bool> ApplyLateFeeIfNeededAsync(int receiptId)
        {
            var receipt = await _receiptRepository.GetByIdAsync(receiptId);
            if (receipt == null) return false;

            // Verificar si necesita aplicar mora
            if (DateTime.Now > receipt.DueDate && !receipt.LateFeeApplied)
            {
                receipt.LateFee = await CalculateLateFeeAsync(receiptId);
                receipt.LateFeeApplied = true;
                receipt.LateFeeAppliedDate = DateTime.Now;

                // Actualizar el monto total (monto original + mora)
                receipt.Amount += receipt.LateFee;

                _receiptRepository.Update(receipt);
                await _receiptRepository.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
