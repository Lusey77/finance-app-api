using System.Collections.Generic;
using System.Linq;
using FinanceApp.Domain.Entity;
using FinanceApp.Infrastructure.Data;
using FinanceApp.Model;
using FinanceApp.ModelConverter;
using FinanceApp.Service.Interface;

namespace FinanceApp.Service.Class
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _uow;
        private readonly IModelConverter<Account, AccountModel> _converter;

        public AccountService(IUnitOfWork uow, IModelConverter<Account, AccountModel> converter)
        {
            _uow = uow;
            _converter = converter;
        }


        public IEnumerable<Account> Get()
        {
            IEnumerable<Account> accounts = _uow.RepositoryOf<Account>()
                .FindWhere(account => account.State == State.Inactive);

            return accounts;
        }



        public IEnumerable<Account> GetInactiveAccounts()
        {
            IEnumerable<Account> accounts = _uow.RepositoryOf<Account>()
                .FindWhere(account => account.State == State.Inactive);

            return accounts;
        }



        public IEnumerable<AccountModel> GetAccounts()
        {
            return 
                _uow.RepositoryOf<Account>()
                    .FindWhere(account => account.State == State.Active)
                    .Select(account => _converter.Convert(account));
        }

        public AccountModel GetAccount(int id)
        {
            return
                _converter.Convert(
                    _uow.RepositoryOf<Account>()
                        .FindWhere(account => account.State == State.Active && account.Id == id)
                        .FirstOrDefault());
        }

        public void CreateAccount(CreateAccountModel model)
        {
            Account accountToCreate = new Account
            {
                Name = model.Name,
                Description = model.Description,
                Balance = 0.0m,
                State = State.Active,
                Transactions = new HashSet<Transaction>() { }
            };

            _uow.RepositoryOf<Account>()
                .CreateEntity(accountToCreate);

            _uow.SaveChanges();
        }

        public void UpdateAccount(UpdateAccountModel model)
        {
            Account accountToUpdate = 
                _uow.RepositoryOf<Account>()
                    .FindWhere(account => account.State == State.Active && account.Id == model.Id)
                    .FirstOrDefault();

            if (accountToUpdate == null) return;

            if (!string.IsNullOrWhiteSpace(model.Name))
                accountToUpdate.Name = model.Name;

            if (model.Description != null)
                accountToUpdate.Description = model.Description;

            if (model.Balance != null)
                accountToUpdate.Balance = model.Balance;

            _uow.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            Account accountToDelete =
                _uow.RepositoryOf<Account>()
                    .FindWhere(account => account.State == State.Active && account.Id == id)
                    .FirstOrDefault();

            if (accountToDelete == null) return;

            accountToDelete.State = State.Inactive;

            _uow.SaveChanges();
        }
    }
}
