using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        void RejectChanges();
        IRepository<TEntity> RepositoryOf<TEntity>() where TEntity : class;
        void SaveChanges();
    }
}
