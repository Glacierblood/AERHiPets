using AERHiPets.Models.GestionAnimal;
using AERHiPets.Models.GestionDireccion;
using AERHiPets.Models.GestionUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AERHiPets.Models.GestionAdopcionApadrinamiento.GestionAdopcion
{
    public class Adopcion
    {
        public int Id { get; set; }

        public int? empleadoId { get; set; }
        public virtual Persona empleado { get; set; }

        public int? voluntarioId { get; set; }
        public virtual Persona voluntario { get; set; }

        public int? animalId { get; set; }
        public virtual Animal animal { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Alta")]
        public DateTime? fechaAlta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Cancelacion")]
        public DateTime? fechaCancelacion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Confirmacion")]
        public DateTime? fechaConfirmacion { get; set; }

        public int? dias { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Fin Tenencia")]
        public DateTime? fechaFin { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Entrega")]
        public DateTime? fechaEntrega { get; set; }

        [Display(Name = "Tenencia Temporal")]
        public Boolean esTemporal { get; set; }

        public int? estadoAdopcionId { get; set; }
        [Display(Name = "Estado")]
        public  virtual EstadoAdopcion estadoAdopcion { get; set; }

        public int? tipoAdopcionId { get; set; }
        [Display(Name = "Tipo Adopcion")]
        public virtual TipoAdopcion tipoAdopcion { get; set; }

        public int? direccionId { get; set; }
        public virtual Direccion direccion { get; set; }

        [StringLength(255)]
        public String EmpleadoUsrId { get; set; }
        [Display(Name = "Nombre Empleado")]
        public String empleadoName { get; set; }

        [StringLength(255)]
        public String VoluntarioUsrId { get; set; }
        [Display(Name = "Nombre Voluntario")]
        public String voluntarioName { get; set; }

       
    }
}