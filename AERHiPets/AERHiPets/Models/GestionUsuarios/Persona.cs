using AERHiPets.Models.GestionDireccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionUsuarios
{
    public class Persona
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimento")]
        public DateTime fechaNac { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Alta")]
        public DateTime? fechaAlta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Baja")]
        public DateTime? fechaBaja { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "No se permiten mas de 15 caracteres.")]
        [Display(Name = "Telefono")]
        public String telefono { get; set; }

        [Required]
        [DataTypeAttribute("BoldRed")]
        [RegularExpression(@"^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$",
            ErrorMessage = "Characters are not allowed.")]
        [StringLength(15, ErrorMessage = "No se permiten mas de 15 caracteres.")]
        [Display(Name = "Telefono Celular")]
        
        public String telefonoCel { get; set; }
        
        public int puntaje { get; set; }

        public int direccionId { get; set; }
        public virtual Direccion direccion { get; set; }

        public virtual ICollection<RegistroAcciones> registrosAcciones { get; set; }

        [StringLength(255)]
        public String UsrId { get; set; }

        public String calleGmaps { get; set; }
        public String lat { get; set; }
        public String lng { get; set; }

    }
}