using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.Business.IRepository;
using PM.Business.Models;

namespace PM.Api.Controllers
{
    [ApiController]
    [Route("v1/Farm")]
    public class FarmController : Controller
    {

        private readonly IFarmRepository _repFarm;
        public FarmController(IFarmRepository repFarm)
        {
            _repFarm = repFarm;
        }
        
       
        [HttpGet]
        [Route("v1/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
           await _repFarm.GetId(id);
            return Ok("Ok");
        }

        [HttpPost]
        [Route("v1/post")]
        public async Task<IActionResult> Post([FromBody] Farm model)
        {
           
            try
            {
                await _repFarm.Create(model);
                return Ok("Ok");
              
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("v1/edit")]
        public async Task<IActionResult> Edit( [FromBody]  Farm model)
        {
            try
            {
                await _repFarm.Edit(model);
                return Ok("Ok");
            }
            catch
            {
                return NotFound();
            }
        }

        
        [HttpPost]
        [Route("v1/{id}")]
        public async Task<IActionResult> Delete(Guid idUser, Guid idFarm)
        {
            try
            {
                await _repFarm.Delete(idUser, idFarm);
                return Ok("Ok");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}