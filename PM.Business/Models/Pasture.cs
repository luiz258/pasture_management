using System;

namespace PM.Business.Models
{
    public class Pasture : Entity  //MATRIZ DE DADOS   AVALI
    {
       
        public Guid UserId { get; private set; }
        public Guid FarmId { get; private set; }
        public string NamePasture { get; private set; }
        public double Area { get; private set; }
        public string GrassType { get; private set; }//tipo de capim no patio
        public string Description  { get; private set; }
        public DateTime DataInitial { get; private set; }// Data inicial do inicio do ciclo do pastejo

        public int QtdAnimals { get; private set; }
        public double WeightMedium { get; private set; }
        public double WeightTotal { get; private set; }
        public string TypeFlock { get; private set; } // tipo de rebanho
        public string Race { get; private set; } // raça
        public DateTime AgeMonths  { get; private set; } // SUBTRAI O NUMERO DE DIAS EM IDADE
        public string Sexo { get; private set; }
        public string Objective { get; private set; }

        public double CapacityUA { get; set; }
        public int RateCapacity { get; set; }
        public int RateFractional { get; set; }
        public string Condition { get; set; }



    }
}
