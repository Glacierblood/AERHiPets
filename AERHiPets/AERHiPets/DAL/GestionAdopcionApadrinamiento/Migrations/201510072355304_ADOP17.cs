namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP17 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Files", new[] { "Incidente_Id" });
            CreateTable(
                "dbo.FileIncidentes",
                c => new
                    {
                        FileIncidenteId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        incidentelId = c.Int(nullable: false),
                        incidente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FileIncidenteId)
                .Index(t => t.incidente_Id);
            
            //DropColumn("dbo.Files", "Incidente_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "Incidente_Id", c => c.Int());
            DropIndex("dbo.FileIncidentes", new[] { "incidente_Id" });
            DropTable("dbo.FileIncidentes");
            CreateIndex("dbo.Files", "Incidente_Id");
        }
    }
}
