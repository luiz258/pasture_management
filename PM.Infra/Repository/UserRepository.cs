using Dapper;
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
        public bool Authenticate(string Email, string PasswordHash)
        {
            return _db.Connection
                .QueryFirstOrDefault<bool>("SELECT CASE WHEN EXISTS( SELECT Id FROM PMUSer WHERE Email=@Email AND PasswordHash=@PasswordHash) THEN CAST( 1 AS BIT) ELSE CAST(0 AS BIT)  END", new
                {
                    @Email = Email,
                    @PasswordHash = PasswordHash
                });
        }

        public async Task Create(User model)
        {
            string sql = "INSERT INTO PMUser(Id, UserName, Telephone, Email, PasswordHash, Office, RoleId, Estado) values(@Id, @UserName, @Telephone, @Email, @PasswordHash, @Office, @RoleId, @Estado)";
            await _db.Connection.ExecuteAsync(sql, model);
        }

        public async Task Delete(User model)
        {
            string sql = "DELETE  FROM PMUser WHERE Id = @Id";
            await _db.Connection.ExecuteAsync(sql, model);
        }

        public async Task Edit(User model)
        {
           string sql = "UPDATE PMUser SET Email=@Email, Password=@Password WHERE Id=@Id";
           await _db.Connection.ExecuteAsync(sql, model);
        }

        public async Task<User> GetAccount(string Email)
        {
            return await _db.Connection.QueryFirstOrDefaultAsync<User>("SELECT Id, RoleId From PMUser  WHERE Email=@Email", new { @Email = Email });
            
        }

        public async Task<IEnumerable<User>> ListAccounts(Guid UserId, Guid FarmId)
        {
           return await  _db.Connection.QueryFirstOrDefaultAsync<List<User>>("SELECT * FROM PMUser WHERE UserId=@UserId AND FarmId=@FarmId ", new { @UserId = UserId, @FarmId = FarmId });
        }


    }
}
