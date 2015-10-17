namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "calleGmaps", c => c.String());
           // AddColumn("dbo.Personas", "lat", c => c.String());
           // AddColumn("dbo.Personas", "lng", c => c.String());
        }
        
        public override void Down()
        {
           // DropColumn("dbo.Personas", "lng");
           // DropColumn("dbo.Personas", "lat");
            DropColumn("dbo.Personas", "calleGmaps");
        }
    }
}
