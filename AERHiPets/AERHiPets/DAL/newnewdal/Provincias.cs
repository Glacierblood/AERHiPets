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
    
    public partial class Provincias
    {
        public Provincias()
        {
            this.Localidades = new HashSet<Localidades>();
        }
    
        public int Id { get; set; }
        public string nombre { get; set; }
        public int pais_id { get; set; }
    
        public virtual ICollection<Localidades> Localidades { get; set; }
        public virtual Paises Paises { get; set; }
    }
}
