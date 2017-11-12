﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Domain.Entity
{
    public class LineItem : BaseModel
    {
        public LineItem()
        {
            this.ItemTags = new HashSet<ItemTag>();
        }

        public string Description { get; set; }
        public decimal Amount { get; set; }

        // Foreign Key
        public long TransactionId { get; set; }
        // Navigation Property
        public virtual Transaction Transaction { get; set; }

        // Foreign Key
        public long TransactionTypeId { get; set; }
        // Navigation Property
        public virtual TransactionType TransactionType { get; set; }

        // Navigation Property(TransactionItem <- ItemTags)
        public virtual ICollection<ItemTag> ItemTags { get; set; }
    }
}
