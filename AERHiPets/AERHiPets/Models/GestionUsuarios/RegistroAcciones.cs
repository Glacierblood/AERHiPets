using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionUsuarios
{
    public class RegistroAcciones
    {
        public int Id { get; set; }

        public DateTime fechaAlta { get; set; }
        public DateTime? fechcaBaja { get; set; }
        
        public String comentario { get; set; }

        public int personaId { get; set; }
        public virtual Persona persona { get; set; }

        public int accionesId { get; set; }
        public virtual Acciones acciones { get; set; }
    }
}