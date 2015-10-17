namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstadoIncidentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        estadoInc = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Incidentes", "estadoIncidenteId", c => c.Int());
            CreateIndex("dbo.Incidentes", "estadoIncidenteId");
            AddForeignKey("dbo.Incidentes", "estadoIncidenteId", "dbo.EstadoIncidentes", "Id");
            DropColumn("dbo.Incidentes", "EstadoIncidente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incidentes", "EstadoIncidente", c => c.String());
            DropForeignKey("dbo.Incidentes", "estadoIncidenteId", "dbo.EstadoIncidentes");
            DropIndex("dbo.Incidentes", new[] { "estadoIncidenteId" });
            DropColumn("dbo.Incidentes", "estadoIncidenteId");
            DropTable("dbo.EstadoIncidentes");
        }
    }
}
