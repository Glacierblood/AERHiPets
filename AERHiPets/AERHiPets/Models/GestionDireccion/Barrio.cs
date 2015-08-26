using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionDireccion
{
    public class Barrio
    {
        public int Id { get; set; }

        public String nombre { get; set; }

        public String codigoPostal { get; set; }
       
        public int localidadId { get; set; }
        public Localidad localidad { get; set; }
    }
}