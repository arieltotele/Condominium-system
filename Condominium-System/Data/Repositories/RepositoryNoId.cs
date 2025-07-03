using Condominium_System.Data.Context;
using Condominium_System.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Repositories
{
    public class RepositoryNoId<T> : IRepositoryNoId<T> where T : AuditableModel
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public RepositoryNoId(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities
                .Where(e => e.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            if (typeof(AuditableModel).IsAssignableFrom(typeof(T)))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var isActiveProperty = Expression.Property(parameter, nameof(AuditableModel.IsActive));
                var isActiveTrue = Expression.Equal(isActiveProperty, Expression.Constant(true));

                var combined = Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(isActiveTrue, Expression.Invoke(predicate, parameter)), parameter
                );

                return await _entities.Where(combined).ToListAsync();
            }
            else
            {
                return await _entities.Where(predicate).ToListAsync();
            }
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Remove(T entity)
        {
            if (entity is AuditableModel auditableEntity)
            {
                auditableEntity.IsActive = false;
                auditableEntity.DeletedAt = DateTime.Now;
                _entities.Update(entity);
            }
            else
            {
                _entities.Remove(entity);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
