using AERHiPets.Models.GestionDireccion;
using AERHiPets.Models.GestionUsuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AERHiPets.DAL.GestionVoluntariosDAL
{
    public class GestionVoluntarioDb : DbContext
    {
        public GestionVoluntarioDb() : base("DefaultConnection")
        {/*
            Database.SetInitializer<AerDb>(null); // Remove default initializer
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;*/
        }
        public DbSet<Persona> personas { get; set; }
        public DbSet<Acciones> acciones { get; set; }
        public DbSet<RegistroAcciones> registroAcciones { get; set; }
        public DbSet<Direccion> direcciones { get; set; }
        public DbSet<Barrio> barrios { get; set; }
        public DbSet<Localidad> localidades { get; set; }
        public DbSet<Provincia> provincias { get; set; }
        

    }
}