namespace AERHiPets.DAL.GestionAnimalesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GA5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Razas", "fechaBaja", c => c.DateTime());
            AddColumn("dbo.Especies", "fechaBaja", c => c.DateTime());
            AddColumn("dbo.Tamanios", "fechaBaja", c => c.DateTime());
            AddColumn("dbo.AtencionMedicas", "fechaBaja", c => c.DateTime());
            AddColumn("dbo.ProductoVeterinarias", "fechaBaja", c => c.DateTime());
            AddColumn("dbo.Veterinarias", "fechaBaja", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Veterinarias", "fechaBaja");
            DropColumn("dbo.ProductoVeterinarias", "fechaBaja");
            DropColumn("dbo.AtencionMedicas", "fechaBaja");
            DropColumn("dbo.Tamanios", "fechaBaja");
            DropColumn("dbo.Especies", "fechaBaja");
            DropColumn("dbo.Razas", "fechaBaja");
        }
    }
}
