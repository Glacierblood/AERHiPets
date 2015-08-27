using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionDireccion
{
    public class Direccion
    {
        public int Id { get; set; }

        
       
        [Display(Name = "Barrio")]
        public int barrioId { get; set; }
        public virtual Barrio barrio { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Calle")]
        public String calle { get; set; }
        
        
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Piso")]
        public String piso { get; set; }
        
       
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Torre")]
        public String Torre { get; set; }
        
     
        [StringLength(5, ErrorMessage = "No se permiten mas de 5 caracteres.")]
        [Display(Name = "Departamento")]
        public String depto { get; set; }

    }
}