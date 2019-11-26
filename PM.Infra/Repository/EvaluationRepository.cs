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
                "Date) values" +
                "(@Id, " +
                "@UserId, " +
                "@FarmId, " +
                "@Period, " +
                "@QtdLeaf, " +
                "@RFS, " +
                "@NFV, " +
                "@Note, " +
                "@Date) ", new { model });
         
        }

        //LISTA DE TODOS OS PASTOS DA PROPRIEDADE
        public async Task<IEnumerable<Pasture>> ListAllEvaluation(Guid FarmId)
        {
            return await _db.Connection.QueryFirstOrDefaultAsync<List<Pasture>>("SELECT * FROM Pasture WHERE FarmId=@FarmId", new { @FarmId = FarmId });
        }

        //LISTA DE TODAS AS AVALIAÇÕES DE UM PASTO DA PROPRIEDADE
        public async Task<IEnumerable<Evaluation>> ListAllEvaluation(DateTime Data, Guid FarmId, Guid PastureId)
        {
            return await _db.Connection.QueryFirstOrDefaultAsync<List<Evaluation>>("SELECT * FROM Evaluation WHERE FarmId=@FarmId and PastureId=@PastureId and Data=@Data", new{ @FarmId = FarmId, @PastureId = PastureId, @Data = Data }); 
        }

        //BUSCA DA AVALIAÇÃO DE UM PASTO DA PROPRIEDADE 30 DIAS DA AVALIAÇÃO ANTERIOR
        public async Task<IEnumerable<Evaluation>> ListEvaluationThirtyDays(Guid FarmId, Guid PastureId)
        {
            return await _db.Connection.QueryFirstOrDefaultAsync<List<Evaluation>>("SELECT * FROM Evaluation WHERE FarmId=@FarmId and PastureId=@PastureId and Data  BETWEEN DATEADD(MONTH, 0, CONVERT(Date, GETDATE())) AND DATEADD(MONTH, 1, CONVERT(DATE, GETDATE()))", new { @FarmId = FarmId, @PastureId = PastureId });

        }

        //FAZER JOIN DA TABELA PASTURE E EVALUATION PEGA  ATRIBUTO: DA VALUTION E JUNTA COM A 
        //busca o numero de dias que foi feita a avaliação
        public async Task<IEnumerable<Evaluation>>GetDayPeriod(DateTime Date, Guid FarmId)
        {
            return await _db.Connection.QueryFirstOrDefaultAsync<List<Evaluation>>("SELECT DATEDIFF(DAY, Date=@Date, GETDATE())", new { @Date = Date });
        }

        Task<IEnumerable<Evaluation>> IEvaluationRepository.ListAllEvaluation(Guid FarmId)
        {
            throw new NotImplementedException();
        }
    }
}
