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
        Task<User> GetById(Guid UserId, Guid FarmId);//obter detahe de uma fazenda
        Task<IEnumerable<User>> ListAccounts();
        Task<IEnumerable<User>> ListUsers(Guid UserId, Guid FarmId);
        Task<User> GetIdUser(Guid Id);
        bool Authenticate(string Email, string Password);
        Task<User> GetUser(string Email);
    }
}
