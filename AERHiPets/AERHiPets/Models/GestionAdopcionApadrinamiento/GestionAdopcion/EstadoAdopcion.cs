using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAdopcionApadrinamiento.GestionAdopcion
{
    public class EstadoAdopcion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Estado Adopcion")]
        public String nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Descripcion")]
        public String descripcion { get; set; }
        

    }
}