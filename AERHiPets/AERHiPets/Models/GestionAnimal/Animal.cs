using AERHiPets.Models.GestionAnimal.GestionAnimalImagenes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAnimal
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Nombre")]
        public String nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimento")]
        public DateTime fechaNac { get; set; }

        [Display(Name = "Fecha de Alta")]
        public DateTime fechaAlta { get; set; }
        public int edad { get; set; }

        [Display(Name = "Fecha de Baja")]
        public DateTime? fechaBaja { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "No se permiten mas de 150 caracteres.")]
        [Display(Name = "Caracteristicas")]
        public String caracteristicas { get; set; }

        [Display(Name = "Tamaño")]
        public int? tamanioId { get; set; }
        public Tamanio tamanio { get; set; }

        [Display(Name = "Raza")]
        public int? razaId { get; set; }
        [Display(Name = "Raza")]
        public Raza raza { get; set; }

        [Required]
        [Display(Name = "Adopcion")]
        public Boolean enAdopcion { get; set; }

        public virtual ICollection<FilePath> filePaths { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}