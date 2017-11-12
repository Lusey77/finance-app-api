using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Domain.Entity
{
    public class Transaction : BaseModel
    {
        public Transaction()
        {
            this.LineItems = new HashSet<LineItem>();
            this.TransactionTags = new HashSet<TransactionTag>();
        }

        public string Description { get; set; }
        public byte[] Attachement { get; set; }
        public DateTimeOffset Date { get; set; }

        // Foreign Key
        public long AccountId { get; set; }
        // Navigation Property(Transaction -> Account)
        public virtual Account Account { get; set; }

        // Foreign Key
        public long UserId { get; set; }
        // Navigation Property(Transaction -> User)
        public virtual User User { get; set; }

        // Navigation Property(Transaction <- TransactionItems)
        public virtual ICollection<LineItem> LineItems { get; set; }

        // Navigation Property(Transaction <- TransactionTags)
        public virtual ICollection<TransactionTag> TransactionTags { get; set; }
    }
}
