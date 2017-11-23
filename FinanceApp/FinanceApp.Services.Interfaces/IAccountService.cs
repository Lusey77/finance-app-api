using System.Collections.Generic;
using FinanceApp.Model;

namespace FinanceApp.Service.Interface
{
    public interface IAccountService
    {
        IEnumerable<AccountModel> GetAccounts();
        AccountModel GetAccount(int id);
        void CreateAccount(CreateAccountModel account);
        void UpdateAccount(UpdateAccountModel account);
        void DeleteAccount(int id);
    }
}