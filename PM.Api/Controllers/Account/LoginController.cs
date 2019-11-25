using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PM.Api.Controllers.Service;
using PM.Business.IRepository;
using PM.Business.Models;
using PM.Infra.Repository;

namespace PM.Api.Controllers.Account
{
    [Route("v1/account")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _repUser;
        public LoginController(IUserRepository repUser)
        {
            _repUser = repUser;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            
            //if false return NotFound
            if (!_repUser.Authenticate(model.Email, model.Password))
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var user = await _repUser.GetUser(model.Email);

            var token = TokenService.GenerateToken(user);
            return new
            {
                user = user,
                token = token
            };
        }

        //Test Routes, Authorization
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "consult,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";
    }
}