namespace AERHiPets.DAL.GestionVoluntariosDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VOL1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                        isSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistroAcciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fechaAlta = c.DateTime(nullable: false),
                        fechcaBaja = c.DateTime(),
                        comentario = c.String(),
                        personaId = c.Int(nullable: false),
                        accionesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Acciones", t => t.accionesId, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.personaId, cascadeDelete: true)
                .Index(t => t.personaId)
                .Index(t => t.accionesId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        fechaNac = c.DateTime(nullable: false),
                        fechaAlta = c.DateTime(),
                        fechaBaja = c.DateTime(),
                        telefono = c.String(nullable: false, maxLength: 15),
                        telefonoCel = c.String(nullable: false, maxLength: 15),
                        puntaje = c.Int(nullable: false),
                        direccionId = c.Int(nullable: false),
                        UsrId = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Direccions", t => t.direccionId, cascadeDelete: true)
                .Index(t => t.direccionId);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        barrioId = c.Int(nullable: false),
                        calle = c.String(nullable: false, maxLength: 50),
                        piso = c.String(maxLength: 50),
                        Torre = c.String(maxLength: 50),
                        depto = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barrios", t => t.barrioId, cascadeDelete: true)
                .Index(t => t.barrioId);
            
            CreateTable(
                "dbo.Barrios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(maxLength: 50),
                        codigoPostal = c.String(maxLength: 10),
                        localidadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidads", t => t.localidadId, cascadeDelete: true)
                .Index(t => t.localidadId);
            
            CreateTable(
                "dbo.Localidads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        provinciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincias", t => t.provinciaId, cascadeDelete: true)
                .Index(t => t.provinciaId);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistroAcciones", "personaId", "dbo.Personas");
            DropForeignKey("dbo.Personas", "direccionId", "dbo.Direccions");
            DropForeignKey("dbo.Direccions", "barrioId", "dbo.Barrios");
            DropForeignKey("dbo.Barrios", "localidadId", "dbo.Localidads");
            DropForeignKey("dbo.Localidads", "provinciaId", "dbo.Provincias");
            DropForeignKey("dbo.RegistroAcciones", "accionesId", "dbo.Acciones");
            DropIndex("dbo.Localidads", new[] { "provinciaId" });
            DropIndex("dbo.Barrios", new[] { "localidadId" });
            DropIndex("dbo.Direccions", new[] { "barrioId" });
            DropIndex("dbo.Personas", new[] { "direccionId" });
            DropIndex("dbo.RegistroAcciones", new[] { "accionesId" });
            DropIndex("dbo.RegistroAcciones", new[] { "personaId" });
            DropTable("dbo.Provincias");
            DropTable("dbo.Localidads");
            DropTable("dbo.Barrios");
            DropTable("dbo.Direccions");
            DropTable("dbo.Personas");
            DropTable("dbo.RegistroAcciones");
            DropTable("dbo.Acciones");
        }
    }
}
