namespace AERHiPets.DAL.GestionUsuariosDAL.Migrations1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USR2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Localidads", "provincia_Id", "dbo.Provincias");
            DropIndex("dbo.Localidads", new[] { "provincia_Id" });
            RenameColumn(table: "dbo.Localidads", name: "provincia_Id", newName: "provinciaId");
            AlterColumn("dbo.Localidads", "provinciaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Localidads", "provinciaId");
            AddForeignKey("dbo.Localidads", "provinciaId", "dbo.Provincias", "Id", cascadeDelete: true);
            DropColumn("dbo.Localidads", "provinviaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Localidads", "provinviaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Localidads", "provinciaId", "dbo.Provincias");
            DropIndex("dbo.Localidads", new[] { "provinciaId" });
            AlterColumn("dbo.Localidads", "provinciaId", c => c.Int());
            RenameColumn(table: "dbo.Localidads", name: "provinciaId", newName: "provincia_Id");
            CreateIndex("dbo.Localidads", "provincia_Id");
            AddForeignKey("dbo.Localidads", "provincia_Id", "dbo.Provincias", "Id");
        }
    }
}
