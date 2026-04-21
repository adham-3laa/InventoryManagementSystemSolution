using InventoryManagementSystem.Domain.Contracts.Repos;
using InventoryManagementSystem.Domain.Contracts.UOW;
using InventoryManagementSystem.Domain.Entities.Base;
using InventoryManagementSystem.Persistence.Context;
using InventoryManagementSystem.Persistence.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Persistence.UOW
{
    public class UnitOfWork(InventoryDbContext context) : IUnitOfWork
    {
       
        private readonly Dictionary<Type, object> _repos = new();

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
        {
            var entityType = typeof(TEntity);

            if (!_repos.TryGetValue(entityType, out var repo))
            {
                repo = new GenericRepository<TEntity, TKey>(context);
                _repos[entityType] = repo;
            }

            return (IGenericRepository<TEntity, TKey>)repo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
        
        
    }
}
