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
                   "UserId, " +
                   "FarmId," +
                   "Name, " +
                   "Area, " +
                   "GrassType, " +
                   "Description, " +
                   "DataInitial," +
                   "QtdAnimals," +
                   "WeightMedium," +
                   "WeightTotal," +
                   "TypeFlock," +
                   "Breed," +
                   "AgeMonths," +
                   "Sexo," +
                   "Objective) values " +
                   "(@Id, " +
                   "@UserId, " +
                   "@FarmId, " +
                   "@Name, " +
                   "@Area, " +
                   "@GrassType, " +
                   "@Description, " +
                   "@DataInitial, " +
                   "@QtdAnimals, " +
                   "@WeightMedium, " +
                   "@WeightTotal, " +
                   "@TypeFlock, " +
                   "@Breed, " +
                   "@AgeMonths, " +
                   "@Sexo," +
                   "@Objective) ";
            
              await _db.Connection.ExecuteAsync(sql, model);
            

        }

        public async Task Edit(Pasture model)
        {
            string sql = "UPDATE Pasture SET " +
                   "PastureId=@PastureId, " +
                   "UserId=@UserId, " +
                   "FarmId=@UserId, " +
                   "Name=@UserId, " +
                   "Area=@Area, " +
                   "GrassType=@GrassType, " +
                   "Description=@Description, " +
                   "DataInitial=@DataInitial, " +
                   "QtdAnimals=@QtdAnimals, " +
                   "WeightMedium=@WeightMedium, " +
                   "WeightTotal=@WeightTotal, " +
                   "TypeFlock=@TypeFlock, " +
                   "Breed=@Breed, " +
                   "AgeMonths=@AgeMonths, " +
                   "Sexo=@Sexo, " +
                   "Objective@Objective  where UserId=@UserId ";

            await _db.Connection.ExecuteAsync(sql, model);
            
        }
      
        public async Task Delete(Guid UserId, Guid Id)
        {

            await _db.Connection.ExecuteAsync("DELETE FROM Pasture WHERE UserId=@Id AND Id=@Id");
        }

        public Task<IEnumerable<Pasture>> ListPasture()
        {
            throw new NotImplementedException(); 
        }

        public Task<Pasture>Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
