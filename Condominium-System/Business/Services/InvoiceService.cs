using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepositoryWithId<Invoice> _repository;

        public InvoiceService(IRepositoryWithId<Invoice> invoiceRepository)
        {
            _repository = invoiceRepository;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _repository.GetAllWithIncludesAsync(i => i.Tenant);
        }

        public async Task<Invoice> GetByIdAsync(int id)
        {
            return await _repository.GetByIdWithIncludesAsync(id, i => i.Tenant);
        }

        public async Task<IEnumerable<Invoice>> SearchInvoicesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllAsync();
            }

            var results = new List<Invoice>();

            if (searchTerm.All(char.IsDigit) && int.TryParse(searchTerm, out int id))
            {
                var invoiceById = await GetByIdAsync(id);
                if (invoiceById != null)
                {
                    results.Add(invoiceById);
                }
            }

            var invoicesByDetail = await _repository.FindAsync(i =>
                i.Detail.Contains(searchTerm));

            results.AddRange(invoicesByDetail);

            return results
                .DistinctBy(i => i.Id)
                .OrderByDescending(i => i.IssueDate)
                .ToList();
        }

        public async Task<Invoice> CreateAsync(Invoice invoice)
        {
            await _repository.AddAsync(invoice);
            await _repository.SaveChangesAsync();
            return invoice;
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            _repository.Update(invoice);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var invoice = await _repository.GetByIdAsync(id);
            if (invoice != null)
            {
                _repository.Remove(invoice);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
