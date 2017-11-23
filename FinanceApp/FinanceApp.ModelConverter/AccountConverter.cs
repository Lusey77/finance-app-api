using FinanceApp.Domain.Entity;
using FinanceApp.Model;

namespace FinanceApp.ModelConverter
{
    public class AccountConverter : IModelConverter<Account, AccountModel>
    {
        public AccountModel Convert(Account model)
        {
            if (model.Equals(null)) return null;

            return new AccountModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Balance = model.Balance
            };
        }

        public Account Revert(AccountModel model)
        {
            if (model.Equals(null)) return null;

            return new Account
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Balance = model.Balance
            };
        }
    }
}
