using InventoryManagementSystem.Domain.Contracts.Specifications;
using InventoryManagementSystem.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Persistence
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuary<TEntity, TKey>(IQueryable<TEntity> BaseQuery, ISpecifications<TEntity, TKey> specifications)
            where TEntity : BaseEntity<TKey>
        {
            var query = BaseQuery;
            if (specifications.Criteria != null)
            {
                query = query.Where(specifications.Criteria);
            }

            if(specifications.OrderBy != null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            else if (specifications.OrderByDesc != null)
            {
                query = query.OrderByDescending(specifications.OrderByDesc);
            }

            if (specifications.Includes != null && specifications.Includes.Any())
            {
                query = specifications.Includes.Aggregate(query, (currentQuery, Expression) => currentQuery.Include(Expression));
            }
            return query;
        }
    }
}
