using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAnimal
{
    public class Veterinaria
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Veterinaria")]
        public String nombre { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "No se permiten mas de 255 caracteres.")]
        [Display(Name = "Direccion")]
        public String direccion { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "No se permiten mas de 15 caracteres.")]
        [Display(Name = "Telefono")]
        public String telefono { get; set; }

        [Display(Name = "Fecha de Baja")]
        public DateTime? fechaBaja { get; set; }

    }
}