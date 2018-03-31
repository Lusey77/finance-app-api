using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Domain.Entity
{
    public sealed class LineItem : BaseModel
    {
        public LineItem()
        {
            ItemTags = new HashSet<ItemTag>();
        }

        public string Description { get; set; }
        public decimal Amount { get; set; }

        // Foreign Key
        public long TransactionId { get; set; }
        // Navigation Property
        public Transaction Transaction { get; set; }

        // Foreign Key
        public long TransactionTypeId { get; set; }
        // Navigation Property
        public TransactionType TransactionType { get; set; }

        // Navigation Property(TransactionItem <- ItemTags)
        public ICollection<ItemTag> ItemTags { get; set; }
    }
}
