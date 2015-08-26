using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionDireccion
{
    public class Direccion
    {
        public int Id { get; set; }

        public int barrioId { get; set; }
        public virtual Barrio barrio { get; set; }

        public String calle { get; set; }
        public int piso { get; set; }
        public int Torre { get; set; }
        public Char depto { get; set; }

    }
}