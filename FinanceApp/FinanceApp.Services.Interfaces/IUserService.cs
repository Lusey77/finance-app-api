using System.Collections.Generic;
using FinanceApp.Model;

namespace FinanceApp.Service.Interface
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAccounts();
        UserModel GetAccount(long id);
        void CreateAccount(CreateUserModel account);
        void UpdateAccount(UpdateUserModel account);
        void DeleteAccount(long id);
    }
}
