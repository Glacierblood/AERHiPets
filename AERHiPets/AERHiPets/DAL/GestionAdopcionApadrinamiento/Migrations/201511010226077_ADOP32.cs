namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP32 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Barrios", "Zona", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Barrios", "Zona");
        }
    }
}
