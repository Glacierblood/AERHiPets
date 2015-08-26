using AERHiPets.Models.GestionDireccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionUsuarios
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime fechaNac { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime? fechaBaja { get; set; }
        public int telefono { get; set; }
        public int telefonoCel { get; set; }
        public int puntaje { get; set; }

        public int direccionId { get; set; }
        public virtual Direccion direccion { get; set; }

        public virtual ICollection<RegistroAcciones> registrosAcciones { get; set; }

    }
}