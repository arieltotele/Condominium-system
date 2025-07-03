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
    public class RepositoryWithId<T> : IRepositoryWithId<T> where T : BaseModel
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public RepositoryWithId(AppDbContext context)
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

        public async Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (typeof(AuditableModel).IsAssignableFrom(typeof(T)))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var isActiveProperty = Expression.Property(parameter, nameof(AuditableModel.IsActive));
                var isActiveTrue = Expression.Equal(isActiveProperty, Expression.Constant(true));
                var lambda = Expression.Lambda<Func<T, bool>>(isActiveTrue, parameter);

                query = query.Where(lambda);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            IQueryable<T> query = _entities;

            if (typeof(AuditableModel).IsAssignableFrom(typeof(T)))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var idProperty = Expression.Property(parameter, nameof(BaseModel.Id));
                var idValue = Expression.Equal(idProperty, Expression.Constant(id));
                var isActiveProperty = Expression.Property(parameter, nameof(AuditableModel.IsActive));
                var isActiveTrue = Expression.Equal(isActiveProperty, Expression.Constant(true));

                var combined = Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(idValue, isActiveTrue), parameter
                );

                return await query.FirstOrDefaultAsync(combined);
            }
            else
            {
                return await _entities.FindAsync(id);
            }
        }

        public async Task<T> GetByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (typeof(AuditableModel).IsAssignableFrom(typeof(T)))
            {
                return await query.FirstOrDefaultAsync(e => e.Id == id && ((AuditableModel)(object)e).IsActive);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Where(predicate);

            if (typeof(AuditableModel).IsAssignableFrom(typeof(T)))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var isActiveProperty = Expression.Property(parameter, nameof(AuditableModel.IsActive));
                var isActiveTrue = Expression.Equal(isActiveProperty, Expression.Constant(true));
                var isActiveLambda = Expression.Lambda<Func<T, bool>>(isActiveTrue, parameter);

                query = query.Where(isActiveLambda);
            }

            return await query.ToListAsync();
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
            if (entity is AuditableModel auditable)
            {
                auditable.IsActive = false;
                auditable.DeletedAt = DateTime.Now;
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
