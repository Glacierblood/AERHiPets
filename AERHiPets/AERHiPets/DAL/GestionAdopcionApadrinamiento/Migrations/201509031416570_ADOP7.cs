namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adopcions", "empleadoName", c => c.String());
            AddColumn("dbo.Adopcions", "voluntarioName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adopcions", "voluntarioName");
            DropColumn("dbo.Adopcions", "empleadoName");
        }
    }
}
