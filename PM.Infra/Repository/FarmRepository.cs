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
    public class FarmRepository : IFarmRepository
    {
        private readonly PMDataContext _db;
        public FarmRepository(PMDataContext db)
        {
            _db = db;
        }
        public async Task Create(Farm model)
        {
            await _db.Connection.ExecuteAsync("INSERT INTO Farm(" +
                "Id, " +
                "PMUserId, " +
                "FarmName, " +
                "Document" +
                "Area, " +
                "FarmAddress, " +
                "City, " +
                "UF,)values" +
                "(@Id," +
                "@PMUserId" +
                "@Name" +
                "@Document" +
                "@Area" +
                "@FarmAddress" +
                "@City" +
                "@UF) ", new {  model });
        }

        public async Task Delete(Guid UserId, Guid FarmId)
        {
            await _db.Connection.ExecuteAsync("DELETE FROM Farm WHERE UserId=@UserId  FarmId=@FarmId", new { @UserId = UserId, @FarmId = FarmId });
        }

        public async Task Edit(Farm model)
        {
            await _db.Connection.ExecuteAsync("UPDATE SET Farm(" +
                "Id=@Id, " +
                "PMUserId=@PMUserId, " +
                "FarmName=@FarmName, " +
                "Document=@Document" +
                "Area=@Area, " +
                "FarmAddress=@FarmAddress, " +
                "City=@City, " +
                "UF=@UF) ", new { model });
        }

        public Task<Guid> GetId(Guid Id)
        {
            throw new NotImplementedException();
        }

        //Pecuarista consulta lista de suas propriedades
        public async Task<IEnumerable<Farm>> ListaFarm(Guid UserId)
        {
            return await _db.Connection.QueryFirstOrDefaultAsync<List<Farm>>("SELECT * FROM Farm WHERE UserId=@UserId", new { @UserId= UserId });
        }

        // Wermerson consulta Lista de Propriedades
        public async Task<IEnumerable<Farm>> ListaFarm()
        {

            return await _db.Connection.QueryFirstOrDefaultAsync<List<Farm>>("SELECT * FROM Farm");
        }
        
    }
}
