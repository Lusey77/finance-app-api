using System.Collections.Generic;

namespace FinanceApp.Domain.Entity
{
    public sealed class Account : BaseModel
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }

        // Navigation Property(Account <- Transaction)
        public ICollection<Transaction> Transactions { get; set; }
    }
}
