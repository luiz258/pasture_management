using PM.Business.Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Business.Models
{
    public class Farm : Entity
    {
       
        public Guid UserId { get; set; }
        public string FarmName { get; set; }
        public Document Document { get; set; }
        public double Area { get; set; }
        public string FarmAddress { get; set; }
        public string City { get; set; }
        public string UF { get; set; }

    }
}
