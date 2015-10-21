namespace AERHiPets.DAL.GestionVoluntariosDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VOL6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "email");
        }
    }
}
