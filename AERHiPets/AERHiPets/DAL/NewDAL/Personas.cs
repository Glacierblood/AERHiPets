//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AERHiPets.DAL.NewDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personas
    {
        public Personas()
        {
            this.Adopcions = new HashSet<Adopcions>();
            this.Adopcions1 = new HashSet<Adopcions>();
            this.Apadrinamientoes = new HashSet<Apadrinamientoes>();
            this.Apadrinamientoes1 = new HashSet<Apadrinamientoes>();
            this.RegistroAcciones = new HashSet<RegistroAcciones>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public System.DateTime fechaNac { get; set; }
        public Nullable<System.DateTime> fechaAlta { get; set; }
        public Nullable<System.DateTime> fechaBaja { get; set; }
        public string telefono { get; set; }
        public string telefonoCel { get; set; }
        public int puntaje { get; set; }
        public int direccionId { get; set; }
        public string UsrId { get; set; }
    
        public virtual ICollection<Adopcions> Adopcions { get; set; }
        public virtual ICollection<Adopcions> Adopcions1 { get; set; }
        public virtual ICollection<Apadrinamientoes> Apadrinamientoes { get; set; }
        public virtual ICollection<Apadrinamientoes> Apadrinamientoes1 { get; set; }
        public virtual Direccions Direccions { get; set; }
        public virtual ICollection<RegistroAcciones> RegistroAcciones { get; set; }
    }
}