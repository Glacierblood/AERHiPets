using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAnimal
{
    public class AtencionMedica
    {
        public int Id { get; set; }

        public int animalId { get; set; }
        public Animal animal { get; set; }

        public int veterinariaId { get; set; }
        public Veterinaria veterinaria { get; set; }

        public int? productoVeterinariaId { get; set; }
        public ProductoVeterinaria productoVeterinaria { get; set; }

        public String  tratamiento { get; set; }
        public String nombreVeterinario { get; set; }
    }
}