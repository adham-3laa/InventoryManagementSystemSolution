using InventoryManagementSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Domain.Contracts.Repos
{
    public interface IGenericRepository <TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
