using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionDireccion
{
    [Table("Localidades")]
    public class Localidad
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Localidad")]
        public String nombre { get; set; }

     
        [Display(Name = "Provincia")]
        public int provinciaId { get; set; }
        public Provincia provincia { get; set; }
    }
}