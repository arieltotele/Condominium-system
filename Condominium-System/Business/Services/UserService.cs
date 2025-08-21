using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWithId<User> _userRepository;

        public UserService(IRepositoryWithId<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllWithIncludesAsync(u => u.Condominium);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdWithIncludesAsync(id, u => u.Condominium);
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllAsync();
            }

            var results = new List<User>();

            if (searchTerm.All(char.IsDigit) && int.TryParse(searchTerm, out int id))
            {
                var userById = await GetByIdAsync(id);
                if (userById != null)
                {
                    results.Add(userById);
                }
            }

            var usersByCriteria = await _userRepository.FindAsync(u =>
                (u.FirstName + " " + u.LastName).Contains(searchTerm) ||
                u.Username.Contains(searchTerm) ||
                u.DocumentNumber.Contains(searchTerm));

            results.AddRange(usersByCriteria);

            return results
                .DistinctBy(u => u.Id)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToList();
        }

        public async Task<User> CreateAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                _userRepository.Remove(user);
                await _userRepository.SaveChangesAsync();
            }
        }

        public async Task<bool> UsernameExistsAsync(string username, int? excludedUserId = null)
        {
            var users = await _userRepository.FindAsync(u =>
                u.Username == username &&
                u.IsActive &&
                (excludedUserId == null || u.Id != excludedUserId.Value));

            return users.Any();
        }
    }
}
