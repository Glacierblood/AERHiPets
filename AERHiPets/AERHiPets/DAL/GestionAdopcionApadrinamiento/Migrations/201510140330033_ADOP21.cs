namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP21 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Incidentes", "lng");
            DropColumn("dbo.Incidentes", "lat");
            AddColumn("dbo.Incidentes", "lat", c => c.String());
            AddColumn("dbo.Incidentes", "lng", c => c.String());
            //AlterColumn("dbo.Incidentes", "lat", c => c.String());
            //AlterColumn("dbo.Incidentes", "lng", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incidentes", "lng", c => c.Double(nullable: false));
            AlterColumn("dbo.Incidentes", "lat", c => c.Double(nullable: false));
        }
    }
}
