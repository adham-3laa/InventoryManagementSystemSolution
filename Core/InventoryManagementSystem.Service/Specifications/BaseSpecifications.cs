using InventoryManagementSystem.Domain.Contracts.Specifications;
using InventoryManagementSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InventoryManagementSystem.Service.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {

        #region Where
        protected BaseSpecifications(Expression<Func<TEntity, bool>> _Criteria)
        {
            Criteria = _Criteria;
        }
        public Expression<Func<TEntity, bool>> Criteria { get; private set; }
        #endregion


        #region Ordering
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

        public Expression<Func<TEntity, object>>? OrderByDesc { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }
        #endregion

        #region Include
        public List<Expression<Func<TEntity, object>>> Includes { get; } = [];

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        #endregion
        #region Pagination
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; set; }

        public void ApplyPagination(int  pageIndex, int pageSize) 
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }
        #endregion

    }
}
