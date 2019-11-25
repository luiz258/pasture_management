using PM.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Business.IRepository
{
    public interface IPastureRepository 
    {
        Task Create(Pasture model);
        Task Edit(Pasture model);
        Task Delete(Guid UserId, Guid Id);
        Task<IEnumerable<Pasture>> ListPasture();
        Task<Pasture>Get(Guid id);

    }
}
