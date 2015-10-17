namespace AERHiPets.DAL.GestionVoluntariosDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VOL4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "calle", c => c.String());
            AddColumn("dbo.Personas", "lat", c => c.String());
            AddColumn("dbo.Personas", "lng", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "lng");
            DropColumn("dbo.Personas", "lat");
            DropColumn("dbo.Personas", "calle");
        }
    }
}
