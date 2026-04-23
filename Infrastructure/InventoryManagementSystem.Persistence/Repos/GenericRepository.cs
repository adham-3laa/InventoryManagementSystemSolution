using InventoryManagementSystem.Domain.Contracts.Repos;
using InventoryManagementSystem.Domain.Contracts.Specifications;
using InventoryManagementSystem.Domain.Entities.Base;
using InventoryManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Persistence.Repos
{
    public class GenericRepository<TEntity, TKey>(InventoryDbContext context) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await context.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(TKey id) => await context.Set<TEntity>().FindAsync(id);

        public async Task AddAsync(TEntity entity) => await context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) => context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => context.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllWithSpecificationsAsync(ISpecifications<TEntity, TKey> specifications)
        {
            return await SpecificationEvaluator.CreateQuary(context.Set<TEntity>().AsQueryable(), specifications).ToListAsync();
        }

        public async Task<TEntity?> GetByIdWithSpecificationsAsync(TKey id, ISpecifications<TEntity, TKey> specifications)
        {
            return await SpecificationEvaluator.CreateQuary(context.Set<TEntity>().AsQueryable(), specifications).FirstOrDefaultAsync();
            
        }
    }
}
