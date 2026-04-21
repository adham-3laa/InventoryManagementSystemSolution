using InventoryManagementSystem.Domain.Contracts.Repos;
using InventoryManagementSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Domain.Contracts.UOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity:BaseEntity<TKey>;
        Task<int> SaveChangesAsync();
    }
}
