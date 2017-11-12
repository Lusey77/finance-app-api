using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Infrastructure.Data
{
    public class FinanceAppContextFactory : IContextFactory
    {
        private readonly DbContextOptions<FinanceAppContext> _options;

        public FinanceAppContextFactory(DbContextOptions<FinanceAppContext> options)
        {
            _options = options;
        }

        public DbContext Create()
        {
            return new FinanceAppContext(_options);
        }
    }
}
