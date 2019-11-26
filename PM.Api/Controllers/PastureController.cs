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
   
  
    public class PastureController : Controller
    {
        private readonly IPastureRepository _repPasture;
           
        public PastureController(IPastureRepository repPasture)
        {
            _repPasture = repPasture;
            
        }        

        [HttpGet("")]
        [AllowAnonymous]
        public string Inicio()
        {
            return "Api PastureManagement"+DateTime.Now;
        }

        
        [HttpGet("v1/pasture")]
        [AllowAnonymous]
        public async Task<IEnumerable<Pasture>> GetListFarm()
        {
            return await _repPasture.ListPasture();
        }
        
        [HttpGet("v1/pasture/{id}")]
        [AllowAnonymous]
        public async Task<IEnumerable<Pasture>> GetListHistoricDatasFarm( Guid farmId)
        {
            return await _repPasture.ListPasture();
        }

       
        [HttpGet("v1/pasture/{id},{id}")]
        [AllowAnonymous]
        public async Task<Pasture> GetDetail(Guid farmId, Guid pastureId)
        {
            return await _repPasture.Get(farmId, pastureId);

        }

     
        [HttpPost("v1/pasture")]
        [AllowAnonymous]
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
        [HttpPut("v1/pasture")]
        [AllowAnonymous]
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
        
        
        [HttpPost("v1/pasture")]
        [AllowAnonymous]
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