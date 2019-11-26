using PM.Business.IRepository;
using PM.Business.Models;
using PM.Infra.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PMDataContext _db;
        public UserRepository(PMDataContext db)
        {
            _db = db;
        }
        public bool Authenticate(string Email, string Password)
        {
            _db.Connection
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
