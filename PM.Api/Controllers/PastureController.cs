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
   
    [ApiController]
    [Route("v1/pasture")]
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

        
        [HttpGet("v1/listPature")]
        [AllowAnonymous]
        public async Task<IEnumerable<Pasture>> GetListFarm()
        {
            return await _repPasture.ListPasture();
        }
        
        [HttpGet("v1/listHistoric/{id:string}")]
        [AllowAnonymous]
        public async Task<IEnumerable<Pasture>> GetListHistoricDatasFarm( Guid farmId)
        {
            return await _repPasture.ListPasture();
        }

       
        [HttpGet("v1/pasture/{id:string},{id:string}")]
        [AllowAnonymous]
        public async Task<Pasture> GetDetail(Guid farmId, Guid pastureId)
        {
            return await _repPasture.Get(farmId, pastureId);

        }

     
        [HttpPost("v1/create")]
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
        [HttpPut("v1/edit/{id:string}")]
        [AllowAnonymous]
        public async Task<IActionResult> Edit([FromBody] Pasture pasture, Guid id)
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
        
        
        [HttpPost("v1/remove/{id:string}{id:string}")]
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