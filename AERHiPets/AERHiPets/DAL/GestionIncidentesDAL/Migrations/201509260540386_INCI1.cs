namespace AERHiPets.DAL.GestionIncidentesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INCI1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        descripcion = c.String(maxLength: 150),
                        tamanioId = c.Int(),
                        razaId = c.Int(),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        telefono = c.String(nullable: false, maxLength: 15),
                        fechaFin = c.DateTime(),
                        fechaAlta = c.DateTime(),
                        fechaBaja = c.DateTime(),
                        EstadoIncidente = c.String(),
                        tipoIncidenteId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Razas", t => t.razaId)
                .ForeignKey("dbo.Tamanios", t => t.tamanioId)
                .ForeignKey("dbo.TipoIncidentes", t => t.tipoIncidenteId)
                .Index(t => t.tamanioId)
                .Index(t => t.razaId)
                .Index(t => t.tipoIncidenteId);
            
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
                        Incidente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Animals", t => t.animalId, cascadeDelete: true)
                .ForeignKey("dbo.Incidentes", t => t.Incidente_Id)
                .Index(t => t.animalId)
                .Index(t => t.Incidente_Id);
            
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
            
            CreateTable(
                "dbo.TipoIncidentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tipoIncidente = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidentes", "tipoIncidenteId", "dbo.TipoIncidentes");
            DropForeignKey("dbo.Incidentes", "tamanioId", "dbo.Tamanios");
            DropForeignKey("dbo.Incidentes", "razaId", "dbo.Razas");
            DropForeignKey("dbo.Files", "Incidente_Id", "dbo.Incidentes");
            DropForeignKey("dbo.Animals", "especieID", "dbo.Especies");
            DropForeignKey("dbo.Animals", "tamanioId", "dbo.Tamanios");
            DropForeignKey("dbo.Animals", "razaId", "dbo.Razas");
            DropForeignKey("dbo.Razas", "especieID", "dbo.Especies");
            DropForeignKey("dbo.Files", "animalId", "dbo.Animals");
            DropForeignKey("dbo.FilePaths", "animalId", "dbo.Animals");
            DropIndex("dbo.Razas", new[] { "especieID" });
            DropIndex("dbo.FilePaths", new[] { "animalId" });
            DropIndex("dbo.Animals", new[] { "especieID" });
            DropIndex("dbo.Animals", new[] { "razaId" });
            DropIndex("dbo.Animals", new[] { "tamanioId" });
            DropIndex("dbo.Files", new[] { "Incidente_Id" });
            DropIndex("dbo.Files", new[] { "animalId" });
            DropIndex("dbo.Incidentes", new[] { "tipoIncidenteId" });
            DropIndex("dbo.Incidentes", new[] { "razaId" });
            DropIndex("dbo.Incidentes", new[] { "tamanioId" });
            DropTable("dbo.TipoIncidentes");
            DropTable("dbo.Tamanios");
            DropTable("dbo.Especies");
            DropTable("dbo.Razas");
            DropTable("dbo.FilePaths");
            DropTable("dbo.Animals");
            DropTable("dbo.Files");
            DropTable("dbo.Incidentes");
        }
    }
}
