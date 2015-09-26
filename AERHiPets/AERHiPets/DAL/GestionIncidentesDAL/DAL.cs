using AERHiPets.Models.GestionIncidentes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AERHiPets.DAL.GestionIncidentesDAL
{
    public class DAL : DbContext
    {
        public DAL() : base("DefaultConnection")
        {/*
            Database.SetInitializer<AerDb>(null); // Remove default initializer
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;*/
        }
        public DbSet<Incidente> incidentes { get; set; }
        public DbSet<TipoIncidente> tipoIncidentes { get; set; }
    }
}