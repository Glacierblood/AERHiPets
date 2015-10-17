namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidentes", "especieId", c => c.Int());
            CreateIndex("dbo.Incidentes", "especieId");
            AddForeignKey("dbo.Incidentes", "especieId", "dbo.Especies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidentes", "especieId", "dbo.Especies");
            DropIndex("dbo.Incidentes", new[] { "especieId" });
            DropColumn("dbo.Incidentes", "especieId");
        }
    }
}
