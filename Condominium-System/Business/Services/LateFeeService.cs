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

            // Here we calculate whether the deadline has passed and whether it has been applied.
            if (DateTime.Now > receipt.DueDate && !receipt.LateFeeApplied)
            {
                int daysLate = (DateTime.Now - receipt.DueDate).Days;

                // Here we apply a 5% late payment fee.
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

            if (DateTime.Now > receipt.DueDate && !receipt.LateFeeApplied)
            {
                receipt.LateFee = await CalculateLateFeeAsync(receiptId);
                receipt.LateFeeApplied = true;
                receipt.LateFeeAppliedDate = DateTime.Now;

                receipt.Amount += receipt.LateFee;

                _receiptRepository.Update(receipt);
                await _receiptRepository.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
