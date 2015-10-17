using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionIncidentes
{
    public class EstadoIncidente
    {
        public int Id { get; set; }
        public String estadoInc { get; set; }
        public String descripcion { get; set; }
    }
}