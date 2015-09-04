namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adopcions", "fechaAlta", c => c.DateTime());
            AlterColumn("dbo.Adopcions", "fechaFin", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adopcions", "fechaFin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "fechaAlta", c => c.DateTime(nullable: false));
        }
    }
}
