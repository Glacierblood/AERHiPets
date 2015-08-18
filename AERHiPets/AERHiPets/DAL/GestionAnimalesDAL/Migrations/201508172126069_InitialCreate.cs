namespace AERHiPets.DAL.GestionAnimalesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Razas", t => t.razaId)
                .ForeignKey("dbo.Tamanios", t => t.tamanioId)
                .Index(t => t.tamanioId)
                .Index(t => t.razaId);
            
            CreateTable(
                "dbo.Razas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        descripcion = c.String(maxLength: 150),
                        especieID = c.Int(),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tamanios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        descripcion = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "tamanioId", "dbo.Tamanios");
            DropForeignKey("dbo.Animals", "razaId", "dbo.Razas");
            DropForeignKey("dbo.Razas", "especieID", "dbo.Especies");
            DropIndex("dbo.Razas", new[] { "especieID" });
            DropIndex("dbo.Animals", new[] { "razaId" });
            DropIndex("dbo.Animals", new[] { "tamanioId" });
            DropTable("dbo.Tamanios");
            DropTable("dbo.Especies");
            DropTable("dbo.Razas");
            DropTable("dbo.Animals");
        }
    }
}
