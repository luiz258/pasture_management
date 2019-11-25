using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.Business.IRepository;
using PM.Business.Models;

namespace PM.Api.Controllers
{
    [Route("v1/pasture")]
    public class PastureController : ControllerBase
    {
        private readonly IPastureRepository _repPasture;
    

        
        public PastureController(IPastureRepository repPasture)
        {
            _repPasture = repPasture;
            
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public string Inicio()
        {
            return "Api UCP"+DateTime.Now;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IEnumerable<Pasture>> GetListFarm()
        {
            return await _repPasture.ListPasture();
        }
        [HttpGet]
        [Route("v1/pasture")]
        public async Task<IEnumerable<Pasture>> GetListHistoricDatasFarm( Guid FarmId)
        {
            return await _repPasture.ListPasture();
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<Pasture> GetPasture(Guid id)
        {
            return await _repPasture.Get(id);

        }

        [HttpPost]
        [Route("v1/pasture")]
        public async Task<IActionResult> Post([FromBody] Pasture pasture )
        {
            try
            {
               await _repPasture.Create(pasture);
                return Ok ("OK");
                
            }
            catch
            {
                return NotFound();
            }
            
        }

        [HttpPut]
        [Route("v1/pasture/{idUser}{idFarm}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Pasture pasture)
        {
            try
            {
                // TODO: Add update logic here
               await _repPasture.Edit(pasture);
                return Ok("ok");
            }
            catch
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        [Route("v1/pasture/{idUser}{id}")]
        public async Task <IActionResult> Remove(Guid idUser, Guid id)
        {
            try
            {
                await _repPasture.Delete(idUser, id);
                return Ok();
            }
            catch
            {                
                    return BadRequest();                
            }
        }


      
    }

    

}