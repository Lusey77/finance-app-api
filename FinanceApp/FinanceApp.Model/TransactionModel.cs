using System;

namespace FinanceApp.Model
{
    public class TransactionModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public byte[] Attachment { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class UpdateTransactionModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public byte[] Attachment { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class CreateTransactionModel
    {
        public string Description { get; set; }
        public byte[] Attachment { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
