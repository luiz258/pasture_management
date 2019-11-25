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
        Task GetEvaluation(Guid FarmId);
        Task GetById(Guid FarmId, Guid PastureId); //Busca Id da fazenda e 
        Task<IEnumerable<Evaluation>> ListEvaluation(Guid FarmId );
    }
}
