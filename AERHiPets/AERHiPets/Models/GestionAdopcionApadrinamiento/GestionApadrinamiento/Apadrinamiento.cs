using AERHiPets.Models.GestionAnimal;
using AERHiPets.Models.GestionUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAdopcionApadrinamiento.GestionApadrinamiento
{
    public class Apadrinamiento
    {
        public int Id { get; set; }

        public int? empleadoId { get; set; }
        public virtual Persona empleado { get; set; }

        public int? voluntarioId { get; set; }
        public virtual Persona voluntario { get; set; }

        public int animalId { get; set; }
        public virtual Animal animal { get; set; }

        public DateTime fechaAlta { get; set; }
        public DateTime fechaCancelacion { get; set; }
        public DateTime fechaConfirmacion { get; set; }

        public DateTime fechaBaja { get; set; }
        public float importe { get; set; }

        public int estadoApadrinamientoId { get; set; }
        public virtual EstadoApadrinamiento estadoApadrinamiento { get; set; }
    }
}