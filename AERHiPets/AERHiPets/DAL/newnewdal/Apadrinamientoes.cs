//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AERHiPets.DAL.newnewdal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Apadrinamientoes
    {
        public int Id { get; set; }
        public Nullable<int> empleadoId { get; set; }
        public Nullable<int> voluntarioId { get; set; }
        public int animalId { get; set; }
        public System.DateTime fechaAlta { get; set; }
        public System.DateTime fechaCancelacion { get; set; }
        public System.DateTime fechaConfirmacion { get; set; }
        public System.DateTime fechaBaja { get; set; }
        public float importe { get; set; }
        public int estadoApadrinamientoId { get; set; }
    
        public virtual Animals Animals { get; set; }
        public virtual EstadoApadrinamientoes EstadoApadrinamientoes { get; set; }
        public virtual Personas Personas { get; set; }
        public virtual Personas Personas1 { get; set; }
    }
}
