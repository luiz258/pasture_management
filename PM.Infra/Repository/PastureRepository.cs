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
    public class PastureRepository : IPastureRepository
    {
        private readonly PMDataContext _db;
        public PastureRepository(PMDataContext db)
        {
            _db = db;
        }
        public async Task Create(Pasture model)
        {
            string sql = "INSERT INTO Pasture (" +
                   "Id, " +
                   "PMUserId, " +
                   "FarmId," +
                   "PastureName, " +
                   "Area, " +
                   "GrassType, " +
                   "PastureDescription, " +
                   "DataInitial," +
                   "QtdAnimals," +
                   "WeightMedium," +
                   "WeightTotal," +
                   "TypeFlock," +
                   "Race," +
                   "AgeMonths," +
                   "Sexo," +
                   "Objective," +
                   "CapacityUA, " +
                   "RateCapacity," +
                   "RateFractional) values " +
                   "(@Id, " +
                   "@PMUserId, " +
                   "@FarmId, " +
                   "@PastureName, " +
                   "@Area, " +
                   "@GrassType, " +
                   "@PastureDescription, " +
                   "@DataInitial, " +
                   "@QtdAnimals, " +
                   "@WeightMedium, " +
                   "@WeightTotal, " +
                   "@TypeFlock, " +
                   "@Race, " +
                   "@AgeMonths, " +
                   "@Sexo," +
                   "@Objective," +
                   "@CapacityUA," +
                   "@RateCapacity," +
                   "@RateFractional) ";

            await _db.Connection.ExecuteAsync(sql, model);
        }

        public async Task Edit(Pasture model)
        {
            string sql = "UPDATE Pasture SET " +
                   "PastureId=@PastureId, " +
                   "PMUserId=@PMUserId, " +
                   "FarmId=@FarmId, " +
                   "PastureName=@PastureName, " +
                   "Area=@Area, " +
                   "GrassType=@GrassType, " +
                   "Description=@Description, " +
                   "DataInitial=@DataInitial, " +
                   "QtdAnimals=@QtdAnimals, " +
                   "WeightMedium=@WeightMedium, " +
                   "WeightTotal=@WeightTotal, " +
                   "TypeFlock=@TypeFlock, " +
                   "Race=@Race, " +
                   "AgeMonths=@AgeMonths, " +
                   "Sexo=@Sexo, " +
                   "Objective@Objective," +
                   "CapacityUA=@CapacityUA," +
                   "RateCapacity=@RateCapacity," +
                   "RateFractional=@RateFractional  WHERE UserId=@UserId ";

            await _db.Connection.ExecuteAsync(sql, model);

        }

        public async Task Delete(Guid UserId, Guid Id)
        {

            await _db.Connection.ExecuteAsync("DELETE FROM Pasture WHERE UserId=@Id AND Id=@Id",new { UserId = @UserId, Id = @Id });
        }

        public Task<IEnumerable<Pasture>> ListPasture()
        {
            throw new NotImplementedException();
        }

        public Task<Pasture> Get(Guid FarmId, Guid PastureId)
        {
            throw new NotImplementedException();
        }

        //Join da tabela Pasture com Evaluation
        public async Task<IEnumerable<Evaluation>> ListAllDataPasture(Guid FarmId, Guid PastureId)
        {
            return await _db.Connection.QueryFirstOrDefaultAsync<List<Evaluation>>("SELECT E.Date, P.PastureName, P.CapacityUA, P.RateCapacityUA, P.RateFractional, P.GrassType, E.Note, E.QtdLeaf, E.RFS, E.NFV P.Condition, E.Period, P.WeightMedium, P.QtdAnimals, P.WeightTotal, P.TypeFlock, P.Race FROM Pasture AS P JOIN Evaluation AS E ON P.Id = E.@PastureId AND  FarmId=@FarmId, AND PastureId=@PastureId", new { @FarmId = FarmId, @PastureId = PastureId });
        }
    }

}
