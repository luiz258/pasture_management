using PM.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Business.IRepository
{
    public interface IEvaluationRepository 
    {
        Task Create(Evaluation model);
        Task<IEnumerable<Evaluation>> ListAllEvaluation(Guid FarmId); 
        Task<IEnumerable<Evaluation>> ListAllEvaluation(DateTime Data, Guid FarmId, Guid PastureId);
        Task<IEnumerable<Evaluation>> ListEvaluationThirtyDays(Guid FarmId, Guid PastureId);


    }
}
