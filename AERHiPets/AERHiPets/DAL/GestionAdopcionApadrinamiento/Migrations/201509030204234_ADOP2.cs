namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adopcions", "UsrId", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adopcions", "UsrId");
        }
    }
}
