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
    
    public partial class Acciones
    {
        public Acciones()
        {
            this.RegistroAcciones = new HashSet<RegistroAcciones>();
        }
    
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool isSelected { get; set; }
    
        public virtual ICollection<RegistroAcciones> RegistroAcciones { get; set; }
    }
}
