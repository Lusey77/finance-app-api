using System;
using System.Collections.Generic;
using System.Linq;
using FinanceApp.Domain.Entity;
using FinanceApp.Infrastructure.Data;
using FinanceApp.Model;
using FinanceApp.ModelConverter;
using FinanceApp.Service.Interface;

namespace FinanceApp.Service.Class
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IModelConverter<User, UserModel> _converter;

        public UserService(IUnitOfWork uow, IModelConverter<User, UserModel> converter)
        {
            _uow = uow;
            _converter = converter;
        }

        public IEnumerable<UserModel> GetAccounts()
        {
            return 
                _uow.RepositoryOf<User>()
                    .FindWhere(user => user.State == State.Active)
                    .Select(user => _converter.Convert(user));
        }

        public UserModel GetAccount(long id)
        {
            return 
                _converter.Convert(
                    _uow.RepositoryOf<User>()
                        .FindWhere(user => user.State == State.Active && user.Id == id)
                        .FirstOrDefault());
        }

        public void CreateAccount(CreateUserModel model)
        {
            User userToCreate = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Phone = model.Phone,
                State = State.Active
            };

            _uow.RepositoryOf<User>()
                .CreateEntity(userToCreate);

            _uow.SaveChanges();
        }

        public void UpdateAccount(UpdateUserModel model)
        {
            User userToUpdate =
                _uow.RepositoryOf<User>()
                    .FindWhere(user => user.State == State.Active && user.Id == model.Id)
                    .FirstOrDefault();

            if (userToUpdate == null) return;

            if (!string.IsNullOrWhiteSpace(model.Password))
                userToUpdate.Password = model.Password;

            if (!string.IsNullOrWhiteSpace(model.Email))
                userToUpdate.Email = model.Email;

            if (!string.IsNullOrWhiteSpace(model.Phone))
                userToUpdate.Phone = model.Phone;

            _uow.SaveChanges();
        }

        public void DeleteAccount(long id)
        {
            User userToDelete =
                _uow.RepositoryOf<User>()
                    .FindWhere(user => user.State == State.Active && user.Id == id)
                    .FirstOrDefault();

            if (userToDelete == null) return;

            userToDelete.State = State.Inactive;

            _uow.SaveChanges();
        }
    }
}
