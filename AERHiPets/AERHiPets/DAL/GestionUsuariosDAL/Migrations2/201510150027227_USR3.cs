namespace AERHiPets.DAL.GestionUsuariosDAL.Migrations2
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USR3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nombreUsuario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "nombreUsuario");
        }
    }
}
