namespace AERHiPets.DAL.GestionAnimalesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GA6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AtencionMedicas", "tratamiento", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.AtencionMedicas", "nombreVeterinario", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AtencionMedicas", "nombreVeterinario", c => c.String());
            AlterColumn("dbo.AtencionMedicas", "tratamiento", c => c.String());
        }
    }
}
