using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAnimal.GestionAnimalModelos
{
    public class AtencionMedicaModelo
    {
        public List<Animal> animales { get; set; }
        public AtencionMedica atencionMedica { get; set; }
        public Animal animal { get; set; }
        public List<Veterinaria> veterinarias { get; set; }
        public List<ProductoVeterinaria> productosVeterinarias { get; set; }
    }
}