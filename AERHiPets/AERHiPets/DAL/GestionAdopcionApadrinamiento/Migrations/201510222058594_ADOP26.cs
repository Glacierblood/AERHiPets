namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidentes", "VoluntarioSolucionUsrId", c => c.String(maxLength: 255));
            AddColumn("dbo.Incidentes", "voluntarioSolucionName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incidentes", "voluntarioSolucionName");
            DropColumn("dbo.Incidentes", "VoluntarioSolucionUsrId");
        }
    }
}
