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
    
    public partial class Razas
    {
        public Razas()
        {
            this.Animals = new HashSet<Animals>();
            this.Incidentes = new HashSet<Incidentes>();
            this.Incidentes1 = new HashSet<Incidentes>();
        }
    
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> especieID { get; set; }
        public Nullable<System.DateTime> fechaBaja { get; set; }
    
        public virtual ICollection<Animals> Animals { get; set; }
        public virtual Especies Especies { get; set; }
        public virtual ICollection<Incidentes> Incidentes { get; set; }
        public virtual ICollection<Incidentes> Incidentes1 { get; set; }
    }
}
