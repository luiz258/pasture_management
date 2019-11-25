using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Business.Models
{
    public class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
