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

        public AppDbContext Context => _context;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities
                .Where(e => e.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            var query = _entities.AsQueryable();

            if (typeof(AuditableModel).IsAssignableFrom(typeof(T)))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var isActiveProperty = Expression.Property(parameter, nameof(AuditableModel.IsActive));
                var isActiveTrue = Expression.Equal(isActiveProperty, Expression.Constant(true));
                var combined = Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(isActiveTrue, Expression.Invoke(predicate, parameter)), parameter
                );

                query = query.Where(combined);
            }
            else
            {
                query = query.Where(predicate);
            }

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            var keyProperties = entityType.FindPrimaryKey().Properties;

            var entries = _context.ChangeTracker.Entries<T>()
                .Where(e => e.State != EntityState.Detached);

            foreach (var entry in entries)
            {
                bool isSameKey = true;

                foreach (var keyProp in keyProperties)
                {
                    var entityKeyValue = keyProp.PropertyInfo.GetValue(entity);
                    var trackedKeyValue = keyProp.PropertyInfo.GetValue(entry.Entity);

                    if (!Equals(entityKeyValue, trackedKeyValue))
                    {
                        isSameKey = false;
                        break;
                    }
                }

                if (isSameKey)
                {
                    entry.State = EntityState.Detached;
                    break;
                }
            }

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

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
