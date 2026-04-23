using InventoryManagementSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InventoryManagementSystem.Domain.Contracts.Specifications
{
    public interface ISpecifications<TEntity, TKey> where TEntity: BaseEntity<TKey>
    {
        //Criteria is use to filter the data based on the condition provided in the expression. It is a lambda expression that takes an entity of type TEntity and returns a boolean value indicating whether the entity satisfies the condition or not.
        // it's read-only to ensure that the criteria is not modified after it is set in the constructor of the specification class. 
        Expression<Func<TEntity, bool>> Criteria { get; }

        //Includes is used to specify the related entities that should be included in the query results. It is a list of lambda expressions that take an entity of type TEntity and return an object representing the related entity to be included. This allows for eager loading of related data, which can improve performance by reducing the number of database queries needed to retrieve the related data.
        List<Expression<Func<TEntity, object>>> Includes { get; }

        Expression<Func<TEntity, object>>? OrderBy { get; }

        Expression<Func<TEntity, object>>? OrderByDesc { get; }

        // take and skip for paginaion 
        int Take {  get; }
        int Skip { get; }

        bool IsPaginated { get; set; }

    }
}
