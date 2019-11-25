using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PM.Business.IRepository;
using PM.Business.Models;

namespace PM.Api.Controllers
{
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationRepository _repEvaluation;
        public EvaluationController(IEvaluationRepository repEvaluation)
        {
            _repEvaluation = repEvaluation;
        }
        //Metodos Evaluation
        [HttpPost]
        [Route("v1/pasture")]
        public async Task<IActionResult> Post([FromBody] Evaluation evaluation)
        {
            try
            {
                await _repEvaluation.Create(evaluation);
                return Ok("OK");

            }
            catch
            {
                return NotFound();
            }

        }

        public async Task<IEnumerable<Evaluation>> GetList(Guid id)
        {
            return await _repEvaluation.ListEvaluation(id);
        }
    }
}