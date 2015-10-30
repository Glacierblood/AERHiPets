using AERHiPets.Models.GestionAnimal;
using AERHiPets.Models.GestionDireccion;
using AERHiPets.Models.GestionUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionIncidentes
{
    public class Incidente
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(150, ErrorMessage = "No se permiten mas de 150 caracteres.")]
        [Display(Name = "Descripcion")]
        public String descripcion { get; set; }

        [Display(Name = "Tamaño")]
        public int? tamanioId { get; set; }
        public Tamanio tamanio { get; set; }

        [Display(Name = "Raza")]
        public int? razaId { get; set; }
        [Display(Name = "Raza")]
        public Raza raza { get; set; }

        [Display(Name = "Especie")]
        public int? especieId { get; set; }
        [Display(Name = "Especie")]
        public Especie Especie { get; set; }

       
        public virtual ICollection<FileIncidente> Files { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "No se permiten mas de 15 caracteres.")]
        [Display(Name = "Telefono")]
        public String telefono { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Fin")]
        public DateTime? fechaFin { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Alta")]
        public DateTime? fechaAlta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Baja")]
        public DateTime? fechaBaja { get; set; }

        public int? estadoIncidenteId { get; set; }
        public EstadoIncidente estadoIncidente { get; set; }

        [Display(Name = "Tipo Incidente")]
        public int? tipoIncidenteId { get; set; }
        public TipoIncidente tipoIncidente { get; set; }

        [StringLength(255)]
        public String VoluntarioUsrId { get; set; }
        [Display(Name = "Nombre Voluntario")]
        public String voluntarioName { get; set; }

        [StringLength(255)]
        public String VoluntarioSolucionUsrId { get; set; }
        [Display(Name = "Nombre Voluntario")]
        public String voluntarioSolucionName { get; set; }

        public int? voluntarioId { get; set; }
        public virtual Persona voluntario { get; set; }

        public String calle { get; set; }
        public String lat { get; set; }
        public String lng { get; set; }

        public Nullable<int> barrioId { get; set; }
        public virtual Barrio Barrios { get; set; }
       
    }
}