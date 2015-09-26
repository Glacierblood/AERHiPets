namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adop10 : DbMigration
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
                "dbo.TipoIncidentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tipoIncidente = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Files", "Incidente_Id", c => c.Int());
            CreateIndex("dbo.Files", "Incidente_Id");
            AddForeignKey("dbo.Files", "Incidente_Id", "dbo.Incidentes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidentes", "tipoIncidenteId", "dbo.TipoIncidentes");
            DropForeignKey("dbo.Incidentes", "tamanioId", "dbo.Tamanios");
            DropForeignKey("dbo.Incidentes", "razaId", "dbo.Razas");
            DropForeignKey("dbo.Files", "Incidente_Id", "dbo.Incidentes");
            DropIndex("dbo.Incidentes", new[] { "tipoIncidenteId" });
            DropIndex("dbo.Incidentes", new[] { "razaId" });
            DropIndex("dbo.Incidentes", new[] { "tamanioId" });
            DropIndex("dbo.Files", new[] { "Incidente_Id" });
            DropColumn("dbo.Files", "Incidente_Id");
            DropTable("dbo.TipoIncidentes");
            DropTable("dbo.Incidentes");
        }
    }
}
