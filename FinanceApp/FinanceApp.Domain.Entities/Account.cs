using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Domain.Entity
{
    public class Account : BaseModel
    {
        public Account()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }

        // Navigation Property(Account <- Transaction)
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
