namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adopcions", "EmpleadoUsrId", c => c.String(maxLength: 255));
            AlterColumn("dbo.Adopcions", "fechaCancelacion", c => c.DateTime());
            AlterColumn("dbo.Adopcions", "fechaConfirmacion", c => c.DateTime());
            AlterColumn("dbo.Adopcions", "fechaEntrega", c => c.DateTime());
            DropColumn("dbo.Adopcions", "AdmUsrId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adopcions", "AdmUsrId", c => c.String(maxLength: 255));
            AlterColumn("dbo.Adopcions", "fechaEntrega", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "fechaConfirmacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcions", "fechaCancelacion", c => c.DateTime(nullable: false));
            DropColumn("dbo.Adopcions", "EmpleadoUsrId");
        }
    }
}
