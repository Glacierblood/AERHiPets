﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities1 : DbContext
    {
        public Entities1()
            : base("name=Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Acciones> Acciones { get; set; }
        public virtual DbSet<Adopcions> Adopcions { get; set; }
        public virtual DbSet<Animals> Animals { get; set; }
        public virtual DbSet<Apadrinamientoes> Apadrinamientoes { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AtencionMedicas> AtencionMedicas { get; set; }
        public virtual DbSet<Barrios> Barrios { get; set; }
        public virtual DbSet<Direccions> Direccions { get; set; }
        public virtual DbSet<Especies> Especies { get; set; }
        public virtual DbSet<EstadoAdopcions> EstadoAdopcions { get; set; }
        public virtual DbSet<EstadoApadrinamientoes> EstadoApadrinamientoes { get; set; }
        public virtual DbSet<EstadoIncidentes> EstadoIncidentes { get; set; }
        public virtual DbSet<FileIncidentes> FileIncidentes { get; set; }
        public virtual DbSet<FilePaths> FilePaths { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Incidentes> Incidentes { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<ProductoVeterinarias> ProductoVeterinarias { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Razas> Razas { get; set; }
        public virtual DbSet<RegistroAcciones> RegistroAcciones { get; set; }
        public virtual DbSet<Tamanios> Tamanios { get; set; }
        public virtual DbSet<TipoAdopcions> TipoAdopcions { get; set; }
        public virtual DbSet<TipoIncidentes> TipoIncidentes { get; set; }
        public virtual DbSet<Veterinarias> Veterinarias { get; set; }
        public virtual DbSet<InformeIncidencias> InformeIncidencias { get; set; }
    }
}
