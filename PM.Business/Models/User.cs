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
        
        public string UserName { get; private set; }
        public string Telephone { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Office { get; private set; } //cargo
        public string Role { get; private set; }  // Pecuarista, Empregado, Consultor
        public bool Estado { get; private set; }
    }
}
