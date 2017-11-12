using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinanceApp.Infrastructure.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IRepository<TEntity> Include(Expression<Func<TEntity, object>> pathExpression);
        void CreateEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
    }
}
