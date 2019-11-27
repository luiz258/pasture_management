using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Business.Models
{
    public class User : Entity
    {
        //public User(string userName, string telephone, string email, string password, string office, string role)
        //{
        //    UserName = userName;
        //    Telephone = telephone;
        //    Email = email;
        //    Password = password;
        //    Office = office;
        //    Role = role;
        //    Estado = true;
        //}
        //public User(string userName,  string password)
        //{
        //    UserName = userName;
        //    Password = password;
        //}
        
        public string UserName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Office { get; set; } //cargo
        public string Role { get; set; }  // Pecuarista, Empregado, Consultor
        public bool Estado { get; set; }
    }
}
