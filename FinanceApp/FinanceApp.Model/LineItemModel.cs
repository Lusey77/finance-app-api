using System;
using System.Collections.Generic;
using System.Text;
using FinanceApp.Domain.Entity;

namespace FinanceApp.Model
{
    public class LineItemModel
    {
        public long Id { get; set; }
        public State State { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
