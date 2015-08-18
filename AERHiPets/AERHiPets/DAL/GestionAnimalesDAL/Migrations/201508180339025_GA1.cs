namespace AERHiPets.DAL.GestionAnimalesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GA1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AtencionMedicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        animalId = c.Int(nullable: false),
                        veterinariaId = c.Int(nullable: false),
                        productoVeterinariaId = c.Int(),
                        tratamiento = c.String(),
                        nombreVeterinario = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.animalId, cascadeDelete: true)
                .ForeignKey("dbo.ProductoVeterinarias", t => t.productoVeterinariaId)
                .ForeignKey("dbo.Veterinarias", t => t.veterinariaId, cascadeDelete: true)
                .Index(t => t.animalId)
                .Index(t => t.veterinariaId)
                .Index(t => t.productoVeterinariaId);
            
            CreateTable(
                "dbo.ProductoVeterinarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        cantidad = c.Int(),
                        descripcion = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Veterinarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        direccion = c.String(nullable: false, maxLength: 255),
                        telefono = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AtencionMedicas", "veterinariaId", "dbo.Veterinarias");
            DropForeignKey("dbo.AtencionMedicas", "productoVeterinariaId", "dbo.ProductoVeterinarias");
            DropForeignKey("dbo.AtencionMedicas", "animalId", "dbo.Animals");
            DropIndex("dbo.AtencionMedicas", new[] { "productoVeterinariaId" });
            DropIndex("dbo.AtencionMedicas", new[] { "veterinariaId" });
            DropIndex("dbo.AtencionMedicas", new[] { "animalId" });
            DropTable("dbo.Veterinarias");
            DropTable("dbo.ProductoVeterinarias");
            DropTable("dbo.AtencionMedicas");
        }
    }
}
