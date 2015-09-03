namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adopcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        empleadoId = c.Int(),
                        voluntarioId = c.Int(),
                        animalId = c.Int(nullable: false),
                        fechaAlta = c.DateTime(nullable: false),
                        fechaCancelacion = c.DateTime(nullable: false),
                        fechaConfirmacion = c.DateTime(nullable: false),
                        dias = c.Int(nullable: false),
                        fechaFin = c.DateTime(nullable: false),
                        fechaEntrega = c.DateTime(nullable: false),
                        esTemporal = c.Boolean(nullable: false),
                        estadoAdopcionId = c.Int(nullable: false),
                        tipoAdopcionId = c.Int(nullable: false),
                        direccionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.animalId, cascadeDelete: true)
                .ForeignKey("dbo.Direccions", t => t.direccionId, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.empleadoId)
                .ForeignKey("dbo.EstadoAdopcions", t => t.estadoAdopcionId, cascadeDelete: true)
                .ForeignKey("dbo.TipoAdopcions", t => t.tipoAdopcionId, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.voluntarioId)
                .Index(t => t.empleadoId)
                .Index(t => t.voluntarioId)
                .Index(t => t.animalId)
                .Index(t => t.estadoAdopcionId)
                .Index(t => t.tipoAdopcionId)
                .Index(t => t.direccionId);
            /*
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        fechaNac = c.DateTime(nullable: false),
                        fechaAlta = c.DateTime(nullable: false),
                        edad = c.Int(nullable: false),
                        fechaBaja = c.DateTime(),
                        caracteristicas = c.String(nullable: false, maxLength: 150),
                        tamanioId = c.Int(),
                        razaId = c.Int(),
                        enAdopcion = c.Boolean(nullable: false),
                        especieID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Razas", t => t.razaId)
                .ForeignKey("dbo.Tamanios", t => t.tamanioId)
                .ForeignKey("dbo.Especies", t => t.especieID, cascadeDelete: true)
                .Index(t => t.tamanioId)
                .Index(t => t.razaId)
                .Index(t => t.especieID);
            /*
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        animalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.Animals", t => t.animalId, cascadeDelete: true)
                .Index(t => t.animalId);
            /*
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        animalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Animals", t => t.animalId, cascadeDelete: true)
                .Index(t => t.animalId);
            /*
            CreateTable(
                "dbo.Razas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        descripcion = c.String(maxLength: 150),
                        especieID = c.Int(),
                        fechaBaja = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Especies", t => t.especieID)
                .Index(t => t.especieID);
            /*
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        descripcion = c.String(maxLength: 150),
                        fechaBaja = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            /*
            CreateTable(
                "dbo.Tamanios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        descripcion = c.String(maxLength: 150),
                        fechaBaja = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            /*
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
            /*
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
            /*
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
            /*
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            /*
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
            /*
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
            /*
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
            */
            CreateTable(
                "dbo.EstadoAdopcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        estadoAdopcion = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoAdopcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tipoAdopcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Apadrinamientoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        empleadoId = c.Int(),
                        voluntarioId = c.Int(),
                        animalId = c.Int(nullable: false),
                        fechaAlta = c.DateTime(nullable: false),
                        fechaCancelacion = c.DateTime(nullable: false),
                        fechaConfirmacion = c.DateTime(nullable: false),
                        fechaBaja = c.DateTime(nullable: false),
                        importe = c.Single(nullable: false),
                        estadoApadrinamientoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.animalId, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.empleadoId)
                .ForeignKey("dbo.EstadoApadrinamientoes", t => t.estadoApadrinamientoId, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.voluntarioId)
                .Index(t => t.empleadoId)
                .Index(t => t.voluntarioId)
                .Index(t => t.animalId)
                .Index(t => t.estadoApadrinamientoId);
            
            CreateTable(
                "dbo.EstadoApadrinamientoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apadrinamientoes", "voluntarioId", "dbo.Personas");
            DropForeignKey("dbo.Apadrinamientoes", "estadoApadrinamientoId", "dbo.EstadoApadrinamientoes");
            DropForeignKey("dbo.Apadrinamientoes", "empleadoId", "dbo.Personas");
            DropForeignKey("dbo.Apadrinamientoes", "animalId", "dbo.Animals");
            DropForeignKey("dbo.Adopcions", "voluntarioId", "dbo.Personas");
            DropForeignKey("dbo.Adopcions", "tipoAdopcionId", "dbo.TipoAdopcions");
            DropForeignKey("dbo.Adopcions", "estadoAdopcionId", "dbo.EstadoAdopcions");
            DropForeignKey("dbo.Adopcions", "empleadoId", "dbo.Personas");
           /*
            DropForeignKey("dbo.RegistroAcciones", "personaId", "dbo.Personas");
            DropForeignKey("dbo.RegistroAcciones", "accionesId", "dbo.Acciones");
            DropForeignKey("dbo.Personas", "direccionId", "dbo.Direccions");
            DropForeignKey("dbo.Adopcions", "direccionId", "dbo.Direccions");
            DropForeignKey("dbo.Direccions", "barrioId", "dbo.Barrios");
            DropForeignKey("dbo.Barrios", "localidadId", "dbo.Localidads");
            DropForeignKey("dbo.Localidads", "provinciaId", "dbo.Provincias");
            */
            DropForeignKey("dbo.Adopcions", "animalId", "dbo.Animals");
            /*
            DropForeignKey("dbo.Animals", "especieID", "dbo.Especies");
            DropForeignKey("dbo.Animals", "tamanioId", "dbo.Tamanios");
            DropForeignKey("dbo.Animals", "razaId", "dbo.Razas");
            DropForeignKey("dbo.Razas", "especieID", "dbo.Especies");
            DropForeignKey("dbo.Files", "animalId", "dbo.Animals");
            DropForeignKey("dbo.FilePaths", "animalId", "dbo.Animals");
            */
            DropIndex("dbo.Apadrinamientoes", new[] { "estadoApadrinamientoId" });
            DropIndex("dbo.Apadrinamientoes", new[] { "animalId" });
            DropIndex("dbo.Apadrinamientoes", new[] { "voluntarioId" });
            DropIndex("dbo.Apadrinamientoes", new[] { "empleadoId" });
            /*
            DropIndex("dbo.RegistroAcciones", new[] { "accionesId" });
            DropIndex("dbo.RegistroAcciones", new[] { "personaId" });
            DropIndex("dbo.Personas", new[] { "direccionId" });
            DropIndex("dbo.Localidads", new[] { "provinciaId" });
            DropIndex("dbo.Barrios", new[] { "localidadId" });
            DropIndex("dbo.Direccions", new[] { "barrioId" });
            DropIndex("dbo.Razas", new[] { "especieID" });
            DropIndex("dbo.Files", new[] { "animalId" });
            DropIndex("dbo.FilePaths", new[] { "animalId" });
            DropIndex("dbo.Animals", new[] { "especieID" });
            DropIndex("dbo.Animals", new[] { "razaId" });
            DropIndex("dbo.Animals", new[] { "tamanioId" });
            */
            DropIndex("dbo.Adopcions", new[] { "direccionId" });
            DropIndex("dbo.Adopcions", new[] { "tipoAdopcionId" });
            DropIndex("dbo.Adopcions", new[] { "estadoAdopcionId" });
            DropIndex("dbo.Adopcions", new[] { "animalId" });
            DropIndex("dbo.Adopcions", new[] { "voluntarioId" });
            DropIndex("dbo.Adopcions", new[] { "empleadoId" });
            DropTable("dbo.EstadoApadrinamientoes");
            DropTable("dbo.Apadrinamientoes");
            DropTable("dbo.TipoAdopcions");
            DropTable("dbo.EstadoAdopcions");
            /*
            DropTable("dbo.Acciones");
            DropTable("dbo.RegistroAcciones");
            DropTable("dbo.Personas");
            DropTable("dbo.Provincias");
            DropTable("dbo.Localidads");
            DropTable("dbo.Barrios");
            DropTable("dbo.Direccions");
            DropTable("dbo.Tamanios");
            DropTable("dbo.Especies");
            DropTable("dbo.Razas");
            DropTable("dbo.Files");
            DropTable("dbo.FilePaths");
            DropTable("dbo.Animals");
            */
            DropTable("dbo.Adopcions");
        }
    }
}
