using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Domain.Entity
{
    public sealed class Transaction : BaseModel
    {
        public Transaction()
        {
            LineItems = new HashSet<LineItem>();
            TransactionTags = new HashSet<TransactionTag>();
        }

        public string Description { get; set; }
        public byte[] Attachement { get; set; }
        public DateTimeOffset Date { get; set; }

        // Foreign Key
        public long AccountId { get; set; }
        // Navigation Property(Transaction -> Account)
        public Account Account { get; set; }

        // Foreign Key
        public long UserId { get; set; }
        // Navigation Property(Transaction -> User)
        public User User { get; set; }

        // Navigation Property(Transaction <- TransactionItems)
        public ICollection<LineItem> LineItems { get; set; }

        // Navigation Property(Transaction <- TransactionTags)
        public ICollection<TransactionTag> TransactionTags { get; set; }
    }
}
