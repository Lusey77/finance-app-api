using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Infrastructure.Data
{
    public interface IContextFactory
    {
        DbContext Create();
    }
}
