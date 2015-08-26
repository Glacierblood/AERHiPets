using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionUsuarios
{
    public class Acciones
    {
        public int Id { get; set; }
        public String nombre { get; set; }
        public String  descripcion { get; set; }
        public Boolean isSelected { get; set; }
        public virtual ICollection<RegistroAcciones> registrosAcciones { get; set; }
        
    }
}