using System;
using System.Collections.Generic;
using System.Text;
using FinanceApp.Domain.Entity;
using FinanceApp.Model;

namespace FinanceApp.ModelConverter
{
    public class UserConverter : IModelConverter<User, UserModel>
    {
        public UserModel Convert(User model)
        {
            if (model.Equals(null)) return null;

            return new UserModel
            {
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Phone = model.Phone
            };
        }

        public User Revert(UserModel model)
        {
            if (model.Equals(null)) return null;

            return new User
            {
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Phone = model.Phone
            };
        }
    }
}
