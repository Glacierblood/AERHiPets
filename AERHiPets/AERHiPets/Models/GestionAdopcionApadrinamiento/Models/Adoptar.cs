using AERHiPets.Models.GestionAdopcionApadrinamiento.GestionAdopcion;
using AERHiPets.Models.GestionAnimal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAdopcionApadrinamiento.Models
{
    public class Adoptar
    {
        public List<Animal> animales { get; set; }
        public List<Especie> especies { get; set; }
        public Animal animal { get; set; }
        public Adopcion adopcion { get; set; }
        public EstadoAdopcion estado { get; set; }
        public TipoAdopcion tipo { get; set; }
        public String UsrID { get; set; }
    }
}