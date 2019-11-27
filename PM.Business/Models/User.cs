using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Business.Models
{
    public class User : Entity
    {

        public string UserName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Office { get; set; } //cargo
        public string RoleId { get; set; }  // Pecuarista, Empregado, Consultor
        public bool Estado => true;
    }
}
