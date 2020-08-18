using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Models;
using System.Collections.Generic;

namespace ErrorHub.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Result<User> Authorize(LoginDomain userData);
        List<User> GetAll();
        User GetByEmail(string email);
        void Save(User user);
        void Update(LoginDomain user);
    }
}
