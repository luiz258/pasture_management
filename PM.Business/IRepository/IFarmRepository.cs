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
        Task Delete(Farm model);
        Task<Farm> GetById(Guid UseId);
        Task<IEnumerable<Farm>> ListaFarm(Guid UserId);

        //Task<IEnumerable<Pasture>> ListHistoricDatasFarm(Guid FarmId); //obter registros das informações geradas  por Id Fazenda
        //Task<Pasture> GetDatas(Guid FarmId);//obter detahe de uma fazenda
    }
}
