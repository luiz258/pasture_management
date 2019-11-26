using PM.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Business.IRepository
{
    public interface IUserRepository
    {
        Task Create(User model);
        Task Edit(User model);
        Task Delete(User model);
        Task<IEnumerable<User>> ListAccounts(Guid UserId, Guid FarmId);
        bool Authenticate(string Email, string Password);
        Task<User> GetAccount(string Email);
    }
}
