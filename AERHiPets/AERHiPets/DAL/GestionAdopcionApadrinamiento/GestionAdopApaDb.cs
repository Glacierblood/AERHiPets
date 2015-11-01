using AERHiPets.Models.GestionAdopcionApadrinamiento;
using AERHiPets.Models.GestionAdopcionApadrinamiento.GestionAdopcion;
using AERHiPets.Models.GestionAdopcionApadrinamiento.GestionApadrinamiento;
using AERHiPets.Models.GestionAnimal.GestionAnimalImagenes;
using AERHiPets.Models.GestionIncidentes;
using AERHiPets.Models.Reportes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AERHiPets.DAL.GestionAdopcionApadrinamiento
{
    public class GestionAdopApaDb : DbContext
    {
         public GestionAdopApaDb() : base("DefaultConnection")
        {
        }
        
         public DbSet<File> Files { get; set; }
         public DbSet<EstadoIncidente> estadoIncidentes { get; set; }
         public DbSet<Adopcion> adopciones { get; set; }
         public DbSet<EstadoAdopcion> estadosAdopciones { get; set; }
         public DbSet<TipoAdopcion> tiposAdopciones { get; set; }

        
         public DbSet<FileIncidente> FileIncidentes { get; set; }
        
         public DbSet<Apadrinamiento> apadrinamientos { get; set; }
         public DbSet<EstadoApadrinamiento> estadosApadrinamientos { get; set; }

         public System.Data.Entity.DbSet<AERHiPets.Models.GestionIncidentes.TipoIncidente> TipoIncidentes { get; set; }

         public System.Data.Entity.DbSet<AERHiPets.Models.GestionIncidentes.Incidente> Incidentes { get; set; }

         public System.Data.Entity.DbSet<AERHiPets.Models.GestionAnimal.Raza> Razas { get; set; }

         public System.Data.Entity.DbSet<AERHiPets.Models.GestionAnimal.Especie> Especies { get; set; }

         public System.Data.Entity.DbSet<AERHiPets.Models.GestionAnimal.Tamanio> Tamanios { get; set; }

         

    }
}