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
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly PMDataContext _db;

        public EvaluationRepository(PMDataContext db)
        {
            _db = db;
        }


        public async Task Create(Evaluation model)
        {
            await _db.Connection.ExecuteAsync("INSERT INTO Evaluation(" +
                "Id, " +
                "UserId, " +
                "FarmId, " +
                "Period" +
                "QtdLeaf, " +
                "RFS, " +
                "NFV, " +
                "Note, " +
                "EvaluationDate, " +
                "CapacityUA, " +
                "RateCapacity, " +
                "RateFractional) values" +
                "(@Id, " +
                "@UserId, " +
                "@FarmId, " +
                "@Period, " +
                "@QtdLeaf, " +
                "@RFS, " +
                "@NFV, " +
                "@Note, " +
                "@EvaluationDate, " +
                "@CapacityUA, " +
                "@RateCapacity, " +
                "@RateFractional) ", new { model });
         
        }

        public Task Evaluation(Guid FarmId)
        {
            throw new NotImplementedException();
        }

        public Task GetById(Guid FarmId, Guid PastureId)
        {
            throw new NotImplementedException();
        }

        public Task GetEvaluation(Guid FarmId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Evaluation>> ListEvaluation(Guid FarmId)
        {
            throw new NotImplementedException();
        }
    }
}
