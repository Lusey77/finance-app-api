﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Domain.Entity
{
    public class TransactionTag : BaseModel
    {
        public string Value { get; set; }

        // Foreign Key
        public long TagTypeId { get; set; }
        // Navigation Property
        public virtual TagType TagType { get; set; }
    }
}
