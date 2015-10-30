namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP25 : DbMigration
    {
        public override void Up()
        {
           // AddColumn("dbo.Personas", "email", c => c.String());
        }
        
        public override void Down()
        {
           // DropColumn("dbo.Personas", "email");
        }
    }
}
