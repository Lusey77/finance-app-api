using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.Model
{
    public class ItemTagModel
    {
        public string Value { get; set; }
        public string Key { get; set; }
    }

    public class UpdateTagModel
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
    }

    public class CreateTagModel
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
    }
}
