using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionDireccion
{
    public class Barrio
    {
        public int Id { get; set; }

        
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Barrio")]
        public String nombre { get; set; }

        
        [StringLength(10, ErrorMessage = "No se permiten mas de 10 caracteres.")]
        [Display(Name = "Codigo Postal")]
        public String codigoPostal { get; set; }

        public int Zona { get; set; }
        
        [Display(Name = "Localidad")]
        public int localidadId { get; set; }
        [Display(Name = "Localidad")]
        public Localidad localidad { get; set; }
    }
}