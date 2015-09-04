namespace AERHiPets.DAL.GestionAdopcionApadrinamiento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADOP6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EstadoAdopcions", "nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.EstadoAdopcions", "descripcion", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.EstadoAdopcions", "estadoAdopcion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EstadoAdopcions", "estadoAdopcion", c => c.String());
            AlterColumn("dbo.EstadoAdopcions", "descripcion", c => c.String());
            DropColumn("dbo.EstadoAdopcions", "nombre");
        }
    }
}
