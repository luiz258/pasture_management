using PM.Business.Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Business.Models
{
    public class Farm : Entity
    {
        protected Farm()
        {
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Document Document { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string UF { get; set; }

    }
}
