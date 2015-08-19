using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAnimal
{
    public class AtencionMedica
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre Mascota")]
        public int animalId { get; set; }
        public Animal animal { get; set; }

        [Required]
        [Display(Name = "Veterinaria")]
        public int veterinariaId { get; set; }
        public Veterinaria veterinaria { get; set; }        
        
        [Display(Name = "Producto")]
        public int? productoVeterinariaId { get; set; }
        public ProductoVeterinaria productoVeterinaria { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Tratamiento")]
        public String  tratamiento { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Nombre")]
        public String nombreVeterinario { get; set; }

        [Display(Name = "Fecha de Baja")]
        public DateTime? fechaBaja { get; set; }
    }
}