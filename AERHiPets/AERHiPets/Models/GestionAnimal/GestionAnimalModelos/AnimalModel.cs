using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAnimal.GestionAnimalModelos
{
    public class AnimalModel
    {
        public List<Animal> animales { get; set; }
        public List<Especie> especies { get; set; }
        public Animal animal { get; set; }
        public Especie especie { get; set; }
    }
}