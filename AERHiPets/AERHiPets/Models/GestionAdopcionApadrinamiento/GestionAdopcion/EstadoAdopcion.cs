using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAdopcionApadrinamiento.GestionAdopcion
{
    public class EstadoAdopcion
    {

        public int Id { get; set; }
        public String estadoAdopcion { get; set; }
        public String descripcion { get; set; }
    }
}