using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PM.Business.IRepository;
using PM.Business.Models;

namespace PM.Api.Controllers
{
    [ApiController]
    [Route("v1/evaluation")]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationRepository _repEvaluation;
        private readonly IPastureRepository _repPasture;
        private readonly IFarmRepository _repFarm;
        public EvaluationController(IEvaluationRepository repEvaluation, IPastureRepository repPasture, IFarmRepository repFarm)
        {
            _repPasture = repPasture;
            _repFarm = repFarm;
            _repEvaluation = repEvaluation;
        }
     
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] Evaluation model)
        { 
            try
            {                
                await _repEvaluation.Create(model);
                return Ok("OK");

            }
            catch
            {
                return NotFound();
            }

        }

        [HttpGet("{id:int}")]
        public async Task<IEnumerable<Evaluation>> GetListAll(Guid farmId)
        {
            return await _repEvaluation.ListAllEvaluation(farmId);
        }


    }
}