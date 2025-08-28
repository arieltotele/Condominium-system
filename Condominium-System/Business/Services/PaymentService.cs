using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Condominium_System.Helpers.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryWithId<Payment> _paymentRepository;
        private readonly IRepositoryWithId<Receipt> _receiptRepository;

        public PaymentService(
            IRepositoryWithId<Payment> paymentRepository,
            IRepositoryWithId<Receipt> receiptRepository)
        {
            _paymentRepository = paymentRepository;
            _receiptRepository = receiptRepository;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllWithIncludesAsync(
                p => p.Receipt
            );
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _paymentRepository.GetByIdWithIncludesAsync(
                id,
                p => p.Receipt
            );
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByReceiptIdAsync(int receiptId)
        {
            return await _paymentRepository.FindAsync(p =>
                p.ReceiptId == receiptId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _paymentRepository.FindAsync(p =>
                p.Date >= startDate && p.Date <= endDate);
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            // Actualizar el monto pagado y estatus en el recibo
            var receipt = await _receiptRepository.GetByIdAsync(payment.ReceiptId);
            if (receipt != null)
            {
                receipt.AmountPaid += payment.AmountPaid;

                // Actualizar el estatus basado en el monto pagado
                receipt.Status = ReceiptStatusHelper.CalculateStatus(receipt.Amount, receipt.AmountPaid);

                _receiptRepository.Update(receipt);
            }

            await _paymentRepository.AddAsync(payment);
            await _paymentRepository.SaveChangesAsync();
            return payment;
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _paymentRepository.Update(payment);
            await _paymentRepository.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment != null)
            {
                // Revertir el pago en el recibo
                var receipt = await _receiptRepository.GetByIdAsync(payment.ReceiptId);
                if (receipt != null)
                {
                    receipt.AmountPaid -= payment.AmountPaid;
                    _receiptRepository.Update(receipt);
                }

                _paymentRepository.Remove(payment);
                await _paymentRepository.SaveChangesAsync();
            }
        }

        public async Task<int> GetTotalPaymentsByReceiptAsync(int receiptId)
        {
            var payments = await GetPaymentsByReceiptIdAsync(receiptId);
            return payments.Sum(p => p.AmountPaid);
        }
    }
}
