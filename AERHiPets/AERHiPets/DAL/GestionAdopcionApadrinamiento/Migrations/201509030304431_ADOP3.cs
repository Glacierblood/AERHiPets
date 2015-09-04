namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adopcions", "AdmUsrId", c => c.String(maxLength: 255));
            AddColumn("dbo.Adopcions", "VoluntarioUsrId", c => c.String(maxLength: 255));
            DropColumn("dbo.Adopcions", "UsrId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adopcions", "UsrId", c => c.String(maxLength: 255));
            DropColumn("dbo.Adopcions", "VoluntarioUsrId");
            DropColumn("dbo.Adopcions", "AdmUsrId");
        }
    }
}
