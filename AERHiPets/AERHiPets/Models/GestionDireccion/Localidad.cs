using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionDireccion
{
    public class Localidad
    {
        public int Id { get; set; }

        public String nombre { get; set; }

        public int provinciaId { get; set; }
        public Provincia provincia { get; set; }
    }
}