using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionDireccion
{
    public class Provincia
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Provincia")]
        public String  nombre { get; set; }

        public int? paisId { get; set; }
        public Pais pais { get; set; }

    }
}