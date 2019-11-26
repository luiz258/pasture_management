using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PM.Business.IRepository;
using PM.Business.Models;
using PM.Infra.Repository;

namespace PM.Api.Controllers.Account
{
    public class UserController : ControllerBase
    {

        private readonly UserRepository _repUser;
        //UserRepository _repUser = new UserRepository(new SQL());
        
        public UserController(UserRepository repUser)
        {
            _repUser = repUser;
        }
        
        [HttpPost("v1/user")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {         
            await _repUser.Create(user);
            return Ok("Ok");
        }
    }
}