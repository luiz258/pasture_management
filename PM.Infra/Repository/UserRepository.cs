using PM.Business.IRepository;
using PM.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool Authenticate(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public Task Create(User model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User model)
        {
            throw new NotImplementedException();
        }

        public Task Edit(User model)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid UserId, Guid FarmId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetIdUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> ListAccounts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> ListUsers(Guid UserId, Guid FarmId)
        {
            throw new NotImplementedException();
        }
    }
}
