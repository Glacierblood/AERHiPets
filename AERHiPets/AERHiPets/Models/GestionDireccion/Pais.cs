using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AERHiPets.Models.GestionDireccion
{   
    [Table("Paises")]
    public class Pais
    {
         public Pais()
        {
            this.Provincias = new HashSet<Provincia>();
        }
    
        public int Id { get; set; }
        public string pais_nombre { get; set; }
    
        public virtual ICollection<Provincia> Provincias { get; set; }
    }
}