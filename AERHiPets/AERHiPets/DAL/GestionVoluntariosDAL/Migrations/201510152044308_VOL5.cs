namespace AERHiPets.DAL.GestionVoluntariosDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VOL5 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Personas", "calleGmaps", c => c.String());
            //DropColumn("dbo.Personas", "calle");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Personas", "calle", c => c.String());
            //DropColumn("dbo.Personas", "calleGmaps");
        }
    }
}
