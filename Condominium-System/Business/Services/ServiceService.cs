using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepositoryWithId<Service> _serviceRepository;

        public ServiceService(IRepositoryWithId<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _serviceRepository.GetAllWithIncludesAsync(s => s.Housings);
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _serviceRepository.GetByIdWithIncludesAsync(id, s => s.Housings);
        }

        public async Task<Service> CreateAsync(Service service)
        {
            await _serviceRepository.AddAsync(service);
            await _serviceRepository.SaveChangesAsync();
            return service;
        }

        public async Task UpdateAsync(Service service)
        {
            _serviceRepository.Update(service);
            await _serviceRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service != null)
            {
                _serviceRepository.Remove(service);
                await _serviceRepository.SaveChangesAsync();
            }
        }
    }
}
