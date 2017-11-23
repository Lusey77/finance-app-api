using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Domain.Entity
{
    public enum State
    {
        Inactive,
        Active
    }

    public class BaseModel
    {
        public long Id { get; set; }
        public State State { get; set; }
    }
}
