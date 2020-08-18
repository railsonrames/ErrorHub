using ErrorHub.Data.Context;
using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Repositories.Interfaces;
using ErrorHub.Domain.Utilities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErrorHub.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ErrorHubContext _context;

        public UserRepository(ErrorHubContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            if (_context.Users.Any())
                return _context.Users.ToList();

            throw new Exception("Não há usuários cadastrados.");
        }

        public User GetByEmail(string email)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Email == email);

            if (user != null)
                return user;

            throw new Exception($"Usuário {email} não encontrado.");
        }

        public void Save(User user)
        {
            var userRecovered = _context.Users
                .FirstOrDefault(x => x.Email == user.Email);

            if (userRecovered != null) throw new Exception($"Usuário com e-mail {user.Email} já cadastrado.");

            user.Password = Md5.Generate(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            var userRecovered = _context.Users
                .FirstOrDefault(x => x.Email == user.Email);

            if (userRecovered == null) throw new Exception($"Usuário {user.Email} não encontrado.");

            userRecovered.Password = Md5.Generate(user.Password);
            _context.Users.Update(userRecovered);
            _context.SaveChanges();
        }
    }
}
