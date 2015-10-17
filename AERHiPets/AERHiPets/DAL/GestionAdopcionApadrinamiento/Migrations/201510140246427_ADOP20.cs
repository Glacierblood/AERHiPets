namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidentes", "calle", c => c.String());
            AddColumn("dbo.Incidentes", "lat", c => c.Double(nullable: false));
            AddColumn("dbo.Incidentes", "lng", c => c.Double(nullable: false));
            DropColumn("dbo.Adopcions", "calle");
            DropColumn("dbo.Adopcions", "lat");
            DropColumn("dbo.Adopcions", "lng");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adopcions", "lng", c => c.Double(nullable: false));
            AddColumn("dbo.Adopcions", "lat", c => c.Double(nullable: false));
            AddColumn("dbo.Adopcions", "calle", c => c.String());
            DropColumn("dbo.Incidentes", "lng");
            DropColumn("dbo.Incidentes", "lat");
            DropColumn("dbo.Incidentes", "calle");
        }
    }
}
