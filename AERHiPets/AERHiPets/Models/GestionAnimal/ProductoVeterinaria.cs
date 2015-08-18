using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAnimal
{
    public class ProductoVeterinaria
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Nombre")]
        public String nombre { get; set; }

        public int? cantidad { get; set; }
        
        [Required]
        [StringLength(255, ErrorMessage = "No se permiten mas de 255 caracteres.")]
        [Display(Name = "Descripcion")]
        public String descripcion { get; set; }
    }
}