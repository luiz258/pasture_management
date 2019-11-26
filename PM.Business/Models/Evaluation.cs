using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Business.Models
{
    public class Evaluation: Entity
    {
   
        public Guid UserId { get; set; }
        public Guid FarmId { get; set; }
        public Guid PastureId { get; set; }
        public string Period { get; set; } // Descanço,  Pastejo
        //public string Condition { get; set; }// SEM GADO,  COM GADO
        public string QtdLeaf { get; set; }  //numero de folhas
        public string RFS { get; set; } // Resisduo de folhas foliar
        public string NFV { get; set; } // Numero de folhas favoraveis
        public double Note { get; set; }  //Altura
        public DateTime Date { get; set; } 

    }
}
