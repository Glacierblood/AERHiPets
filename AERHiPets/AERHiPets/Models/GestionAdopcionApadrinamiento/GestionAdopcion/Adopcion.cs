using AERHiPets.Models.GestionAnimal;
using AERHiPets.Models.GestionDireccion;
using AERHiPets.Models.GestionUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAdopcionApadrinamiento.GestionAdopcion
{
    public class Adopcion
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

        public int dias { get; set; }
        public DateTime fechaFin { get; set; }
        public DateTime fechaEntrega { get; set; }

        public Boolean esTemporal { get; set; }

        public int estadoAdopcionId { get; set; }
        public  virtual EstadoAdopcion estadoAdopcion { get; set; }

        public int tipoAdopcionId { get; set; }
        public virtual TipoAdopcion tipoAdopcion { get; set; }

        public int direccionId { get; set; }
        public virtual Direccion direccion { get; set; }
    }
}