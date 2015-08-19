using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAnimal.GestionAnimalModelos
{
    public class AnimalV : Animal
    {
        public int especieID { get; set; }
        public virtual Especie especie { get; set; }        
    }
}