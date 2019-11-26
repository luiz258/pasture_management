using PM.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Business.IRepository
{
    public interface IFarmRepository
    {
        Task Create(Farm model);
        Task Edit(Farm model);
        Task Delete(Guid UseId, Guid FarmId);
        Task<Guid> GetId(Guid Id);
        Task<IEnumerable<Farm>> ListaFarm(Guid UserId);
        Task<IEnumerable<Farm>> ListaFarm();
    }
}
