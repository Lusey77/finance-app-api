using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FinanceApp.Infrastructure.Data
{
    public class DBContextUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;

        public DBContextUnitOfWork(IContextFactory factory)
        {
            _context = factory.Create();
        }

        public IRepository<TEntity> RepositoryOf<TEntity>() where TEntity : class 
        {
            return new Repository<TEntity>(_context);
        }

        public void ReloadEntity<TEnity>(TEnity entity) where TEnity : class
        {
            _context.Entry(entity).Reload();
        }

        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}