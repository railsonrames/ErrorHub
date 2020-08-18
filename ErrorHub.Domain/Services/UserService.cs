using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Models;
using ErrorHub.Domain.Repositories.Interfaces;
using ErrorHub.Domain.Services.Interfaces;
using ErrorHub.Domain.Utilities;
using System;
using System.Collections.Generic;

namespace ErrorHub.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Result<User> Authorize(LoginDomain userData)
        {
            var user = _repository.GetByEmail(userData.email);
            var result = new Result<User>();
            if (user.Password == Md5.Generate(userData.password))
            {
                result.Success = true;
                result.Message = "Authorized.";
                result.Data = new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                };
            }
            else
            {
                result.Success = false;
                result.Message = "Not authorized.";
            }

            return result;
        }

        public List<User> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User GetByEmail(string email)
        {
            try
            {
                return _repository.GetByEmail(email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Save(User user)
        {
            try
            {
                _repository.Save(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(LoginDomain user)
        {
            try
            {
                _repository.Update(new User
                {
                    Email = user.email,
                    Password = user.password
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
