namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adopcions", "calle", c => c.String());
            //AddColumn("dbo.Adopcions", "lat", c => c.Double(nullable: false));
            //AddColumn("dbo.Adopcions", "lng", c => c.Double(nullable: false));
            //AddColumn("dbo.Incidentes", "lat", c => c.String());
            //AddColumn("dbo.Incidentes", "lng", c => c.String());
            AddColumn("dbo.Incidentes", "VoluntarioUsrId", c => c.String(maxLength: 255));
            AddColumn("dbo.Incidentes", "voluntarioName", c => c.String());
            AddColumn("dbo.Incidentes", "voluntarioId", c => c.Int());
            CreateIndex("dbo.Incidentes", "voluntarioId");
            AddForeignKey("dbo.Incidentes", "voluntarioId", "dbo.Personas", "Id");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidentes", "voluntarioId", "dbo.Personas");
            DropIndex("dbo.Incidentes", new[] { "voluntarioId" });
            DropColumn("dbo.Incidentes", "voluntarioId");
            DropColumn("dbo.Incidentes", "voluntarioName");
            DropColumn("dbo.Incidentes", "VoluntarioUsrId");
            DropColumn("dbo.Adopcions", "lng");
            DropColumn("dbo.Adopcions", "lat");
            DropColumn("dbo.Adopcions", "calle");
        }
    }
}
