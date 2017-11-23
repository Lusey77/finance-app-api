namespace FinanceApp.Model
{
    public class AccountModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
    }

    public class UpdateAccountModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
    }

    public class CreateAccountModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
