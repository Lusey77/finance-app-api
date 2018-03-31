using System.Collections.Generic;
using FinanceApp.Model;

namespace FinanceApp.Service.Interface
{
    public interface ITransactionService
    {
        IEnumerable<TransactionModel> GetAccounts();
        TransactionModel GetAccount(long id);
        void CreateAccount(CreateTransactionModel account);
        void UpdateAccount(UpdateAccountModel account);
        void DeleteAccount(long id);
    }
}