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
    
    public partial class RegistroAcciones
    {
        public int Id { get; set; }
        public System.DateTime fechaAlta { get; set; }
        public Nullable<System.DateTime> fechcaBaja { get; set; }
        public string comentario { get; set; }
        public int personaId { get; set; }
        public int accionesId { get; set; }
    
        public virtual Acciones Acciones { get; set; }
        public virtual Personas Personas { get; set; }
    }
}
