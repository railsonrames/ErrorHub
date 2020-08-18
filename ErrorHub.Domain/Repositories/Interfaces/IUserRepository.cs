using ErrorHub.Domain.Entities;
using System.Collections.Generic;

namespace ErrorHub.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetByEmail(string email);
        void Save(User user);
        void Update(User user);
    }
}
