namespace AERHiPets.DAL.GestionVoluntariosDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VOL8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Barrios", "Zona", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Barrios", "Zona");
        }
    }
}
