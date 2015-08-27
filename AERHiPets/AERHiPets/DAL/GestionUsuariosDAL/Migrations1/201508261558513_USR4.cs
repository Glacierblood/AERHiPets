namespace AERHiPets.DAL.GestionUsuariosDAL.Migrations1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USR4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Direccions", "depto", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Direccions", "depto");
        }
    }
}
